
' TwitPic/OAuth.cs
'
' Code to do OAuth stuff, in support of a cropper plugin that sends
' a screen snap to TwitPic.com.
'
' There's one main class: OAuth.Manager.  It handles interaction with the OAuth-
' enabled service, for requesting temporary tokens (aka request tokens), as well
' as access tokens. It also provides a convenient way to construct an oauth
' Authorization header for use in any Http transaction.
'
' The code has been tested with Twitter and TwitPic, from a desktop application.
'
' -------------------------------------------------------
' Dino Chiesa
' Tue, 14 Dec 2010  12:31
'
' -------------------------------------------------------
' Last saved: <2011-April-20 15:59:04>
'

Imports System.Linq
Imports System.Collections.Generic
Imports System.Security.Cryptography
Namespace IPFAlertService

    ''' <summary>
    '''   A class to manage OAuth interactions.  This works with
    '''   Twitter, not sure about other OAuth-enabled services.
    ''' </summary>
    ''' <remarks>
    '''   <para>
    '''     This class holds the relevant oauth parameters, and exposes
    '''     methods that do things, based on those params.
    '''   </para>
    '''   <para>
    '''     See http://dev.twitpic.com/docs/2/upload/ for an example of the
    '''     oauth parameters.  The params include token, consumer_key,
    '''     timestamp, version, and so on.  In the actual HTTP message, they
    '''     all include the oauth_ prefix, so ..  oauth_token,
    '''     oauth_timestamp, and so on.  You set these via a string indexer.
    '''     If the instance of the class is called oauth, then to set
    '''     the oauth_token parameter, you use oath["token"] in C#.
    '''   </para>
    '''   <para>
    '''     This class automatically sets many of the required oauth parameters;
    '''     this includes the timestamp, nonce, callback, and version parameters.
    '''     (The callback param is initialized to 'oob'). You can reset any of
    '''     these parameters as you see fit.  In many cases you won't have to.
    '''   </para>
    '''   <para>
    '''     The public methods on the class include:
    '''     AcquireRequestToken, AcquireAccessToken,
    '''     GenerateCredsHeader, and GenerateAuthzHeader.  The
    '''     first two are used only on the first run of an applicaiton,
    '''     or after a user has explicitly de-authorized an application
    '''     for use with OAuth.  Normally, the GenerateXxxHeader methods
    '''     can be used repeatedly, when sending HTTP messages that
    '''     require an OAuth Authorization header.
    '''   </para>
    '''   <para>
    '''     The AcquireRequestToken and AcquireAccessToken methods
    '''     actually send out HTTP messages.
    '''   </para>
    '''   <para>
    '''     The GenerateXxxxHeaders are used when constructing and
    '''     sending your own HTTP messages.
    '''   </para>
    ''' </remarks>
    Public Class OAuthManager
        ''' <summary>
        '''   The default public constructor.
        ''' </summary>
        ''' <remarks>
        '''   <para>
        '''     Initializes various fields to default values.
        '''   </para>
        ''' </remarks>
        Public Sub New()
            _random = New Random()
            _params = New Dictionary(Of [String], [String])()
            _params("callback") = ""
            ' presume "desktop" consumer - we are not using this
            _params("consumer_key") = ""
            _params("consumer_secret") = ""
            _params("timestamp") = GenerateTimeStamp()
            _params("nonce") = GenerateNonce()
            _params("signature_method") = "HMAC-SHA256"
            _params("signature") = ""
            _params("token") = ""
            _params("token_secret") = ""
            _params("version") = "1.0"
        End Sub

        ''' <summary>
        '''   The constructor to use when using OAuth when you already
        '''   have an OAuth access token.
        ''' </summary>
        ''' <remarks>
        '''   <para>
        '''     The parameters for this constructor all have the
        '''     meaning you would expect.  The token and tokenSecret
        '''     are set in oauth_token, and oauth_token_secret.
        '''     These are *Access* tokens, obtained after a call
        '''     to AcquireAccessToken.  The application can store
        '''     those tokens and re-use them on successive runs.
        '''     For twitter at least, the access tokens never expire.
        '''   </para>
        ''' </remarks>
        Public Sub New(consumerKey As String, consumerSecret As String, token As String, tokenSecret As String)
            Me.New()
            _params("consumer_key") = consumerKey
            _params("consumer_secret") = consumerSecret
            _params("token") = token
            _params("token_secret") = tokenSecret
        End Sub

        ''' <summary>
        '''   string indexer to get or set oauth parameter values.
        ''' </summary>
        ''' <remarks>
        '''   <para>
        '''     Use the parameter name *without* the oauth_ prefix.
        '''     If you want to set the value for the oauth_token parameter
        '''     field in an HTTP message, then use oauth["token"].
        '''   </para>
        '''   <para>
        '''     The set of oauth param names known by this indexer includes:
        '''     callback, consumer_key, consumer_secret, timestamp, nonce,
        '''     signature_method, signature, token, token_secret, and version.
        '''   </para>
        '''   <para>
        '''     If you try setting a parameter with a name that is not known,
        '''     the setter will throw.  You cannot add new oauth parameters
        '''     using the setter on this indexer.
        '''   </para>
        ''' </remarks>
        Default Public Property Item(ix As String) As String
            Get
                If _params.ContainsKey(ix) Then
                    Return _params(ix)
                End If
                Throw New ArgumentException(ix)
            End Get
            Set(value As String)
                If Not _params.ContainsKey(ix) Then
                    Throw New ArgumentException(ix)
                End If
                _params(ix) = value
            End Set
        End Property


        '' <summary>
        '' Generate the timestamp for the signature.
        '' </summary>
        '' <returns>The timestamp, in string form.</returns>
        Private Function GenerateTimeStamp() As String
            Dim ts As TimeSpan = DateTime.UtcNow - _epoch
            Return Convert.ToInt64(ts.TotalSeconds).ToString()
        End Function

        '' <summary>
        ''   Renews the nonce and timestamp on the oauth parameters.
        '' </summary>
        '' <remarks>
        ''   <para>
        ''     Each new request should get a new, current timestamp, and a
        ''     nonce. This helper method does both of those things. This gets
        ''     called before generating an authorization header, as for example
        ''     when the user of this class calls <see cref='AcquireRequestToken'>.
        ''   </para>
        '' </remarks>
        Private Sub NewRequest()
            _params("nonce") = GenerateNonce()
            _params("timestamp") = GenerateTimeStamp()
        End Sub

        '' <summary>
        '' Generate an oauth nonce.
        '' </summary>
        '' <remarks>
        ''   <para>
        ''     According to RFC 5849, A nonce is a random string,
        ''     uniquely generated by the client to allow the server to
        ''     verify that a request has never been made before and
        ''     helps prevent replay attacks when requests are made over
        ''     a non-secure channel.  The nonce value MUST be unique
        ''     across all requests with the same timestamp, client
        ''     credentials, and token combinations.
        ''   </para>
        ''   <para>
        ''     One way to implement the nonce is just to use a
        ''     monotonically-increasing integer value.  It starts at zero and
        ''     increases by 1 for each new request or signature generated.
        ''     Keep in mind the nonce needs to be unique only for a given
        ''     timestamp!  So if your app makes less than one request per
        ''     second, then using a static nonce of "0" will work.
        ''   </para>
        ''   <para>
        ''     Most oauth nonce generation routines are waaaaay over-engineered,
        ''     and this one is no exception.
        ''   </para>
        '' </remarks>
        '' <returns>the nonce</returns>
        Private Function GenerateNonce() As String
            Dim sb = New System.Text.StringBuilder()

            For i As Integer = 0 To 7
                Dim g As Integer = GetRandomNum(0, 3) + 97
                Select Case g
                    Case 0
                        ' lowercase alpha
                        sb.Append(CChar(ChrW(GetRandomNum(0, 26) + 97)), 1)
                        Exit Select
                    Case Else
                        ' numeric digits
                        sb.Append(CChar(ChrW(GetRandomNum(0, 10) + 48)), 1)
                        Exit Select
                End Select
            Next
            Return sb.ToString()
        End Function

        Private Function GetRandomNum(ByVal startNum As Integer, ByVal endNum As Integer) As String
            Dim ranstring As String
            Dim gap As Integer
            Dim ranNum As Integer
            Dim milSecond As Integer = Now.Millisecond * 123456
            Dim i As Integer = 0

            gap = endNum - startNum
            While milSecond > endNum
                milSecond = CInt(milSecond / gap)
                i = i + 1
            End While

            ranNum = CInt(startNum + milSecond + (-1 ^ i))
            ranstring = ranNum.ToString()
            Return ranstring
        End Function


        '' <summary>
        '' Internal function to extract from a URL all query string
        '' parameters that are not related to oauth - in other words all
        '' parameters not begining with "oauth_".
        '' </summary>
        ''
        '' <remarks>
        ''   <para>
        ''     For example, given a url like http://foo?a=7&guff, the
        ''     returned value will be a Dictionary of string-to-string
        ''     relations.  There will be 2 entries in the Dictionary: "a"=>7,
        ''     and "guff"=>"".
        ''   </para>
        '' </remarks>
        ''
        '' <param name="queryString">The query string part of the Url</param>
        ''
        '' <returns>A Dictionary containing the set of
        '' parameter names and associated values</returns>
        Private Function ExtractQueryParameters(queryString As String) As Dictionary(Of [String], [String])
            If queryString.StartsWith("?") Then
                queryString = queryString.Remove(0, 1)
            End If

            Dim result = New Dictionary(Of [String], [String])()

            If String.IsNullOrEmpty(queryString) Then
                Return result
            End If

            For Each s As String In queryString.Split("&"c)
                If Not String.IsNullOrEmpty(s) AndAlso Not s.StartsWith("oauth_") Then
                    If s.IndexOf("="c) > -1 Then
                        Dim temp As String() = s.Split("="c)
                        result.Add(temp(0), temp(1))
                    Else
                        result.Add(s, String.Empty)
                    End If
                End If
            Next

            Return result
        End Function



        ''' <summary>
        '''   This is an oauth-compliant Url Encoder.  The default .NET
        '''   encoder outputs the percent encoding in lower case.  While this
        '''   is not a problem with the percent encoding defined in RFC 3986,
        '''   OAuth (RFC 5849) requires that the characters be upper case
        '''   throughout OAuth.
        ''' </summary>
        '''
        ''' <param name="value">The value to encode</param>
        '''
        ''' <returns>the Url-encoded version of that string</returns>
        Public Shared Function UrlEncode(value As String) As String
            Dim result = New System.Text.StringBuilder()
            For Each symbol As Char In value
                If unreservedChars.IndexOf(symbol) <> -1 Then
                    result.Append(symbol)
                Else
                    result.Append("%"c + [String].Format("{0:X2}", CInt(AscW(symbol))))
                End If
            Next
            Return result.ToString()
        End Function
        Private Shared unreservedChars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~"


        '' <summary>
        '' Formats the list of request parameters into string a according
        '' to the requirements of oauth. The resulting string could be used
        '' in the Authorization header of the request.
        '' </summary>
        ''
        '' <remarks>
        ''   <para>
        ''     See http://dev.twitter.com/pages/auth#intro  for some
        ''     background.  The output of this is not suitable for signing.
        ''   </para>
        ''   <para>
        ''     There are 2 formats for specifying the list of oauth
        ''     parameters in the oauth spec: one suitable for signing, and
        ''     the other suitable for use within Authorization HTTP Headers.
        ''     This method emits a string suitable for the latter.
        ''   </para>
        '' </remarks>
        ''
        '' <param name="parameters">The Dictionary of
        '' parameters. It need not be sorted.</param>
        ''
        '' <returns>a string representing the parameters</returns>
        Private Shared Function EncodeRequestParameters(p As ICollection(Of KeyValuePair(Of [String], [String]))) As String
            Dim sb = New System.Text.StringBuilder()

            For Each item As KeyValuePair(Of [String], [String]) In p.OrderBy(Function(x) x.Key)
                If Not [String].IsNullOrEmpty(item.Value) AndAlso Not item.Key.EndsWith("secret") Then
                    sb.AppendFormat("oauth_{0}=""{1}"", ", item.Key, UrlEncode(item.Value))
                End If
            Next

            Return sb.ToString().TrimEnd(" "c).TrimEnd(","c)
        End Function



        '' <summary>
        ''   Acquire a request token, from the given URI, using the given
        ''   HTTP method.
        '' </summary>
        ''
        '' <remarks>
        ''   <para>
        ''     To use this method, first instantiate a new Oauth.Manager object,
        ''     then set the callback param (oauth["callback"]='oob'). After the
        ''     call returns, you should direct the user to open a browser window
        ''     to the authorization page for the OAuth-enabled service. Or,
        ''     you can automatically open that page yourself. Do this with
        ''     System.Diagnostics.Process.Start(), passing the URL of the page.
        ''     There should be one query param: oauth_token with the value
        ''     obtained from oauth["token"].
        ''   </para>
        ''   <para>
        ''     According to the OAuth spec, you need to do this only ONCE per
        ''     application.  In other words, the first time the application
        ''     is run.  The normal oauth workflow is:  (1) get a request token,
        ''     (2) use that to acquire an access token (which requires explicit
        ''     user approval), then (3) using that access token, invoke
        ''     protected services.  The first two steps need to be done only
        ''     once per application.
        ''   </para>
        ''   <para>
        ''     For Twitter, at least, you can cache the access tokens
        ''     indefinitely; Twitter says they never expire.  However, other
        ''     oauth services may not do the same. Also: the user may at any
        ''     time revoke his authorization for your app, in which case you
        ''     need to perform the first 2 steps again.
        ''   </para>
        '' </remarks>
        ''
        '' <seealso cref='AcquireAccessToken'>
        ''
        ''
        '' <example>
        ''   <para>
        ''     This example shows how to request an access token and key
        ''     from Twitter. It presumes you've already obtained a
        ''     consumer key and secret via app registration. Requesting
        ''     an access token is necessary only the first time you
        ''     contact the service. You can cache the access key and
        ''     token for subsequent runs, later.
        ''   </para>
        ''   <code>
        ''   // the URL to obtain a temporary "request token"
        ''   var rtUrl = "https://api.twitter.com/oauth/request_token";
        ''   var oauth = new OAuth.Manager();
        ''   // The consumer_{key,secret} are obtained via registration
        ''   oauth["consumer_key"] = "~~~CONSUMER_KEY~~~~";
        ''   oauth["consumer_secret"] = "~~~CONSUMER_SECRET~~~";
        ''   oauth.AcquireRequestToken(rtUrl, "POST");
        ''   var authzUrl = "https://api.twitter.com/oauth/authorize?oauth_token=" + oauth["token"];
        ''   System.Diagnostics.Process.Start(authzUrl);
        ''   // instruct the user to type in the PIN from that browser window
        ''   var pin = "...";
        ''   var atUrl = "https://api.twitter.com/oauth/access_token";
        ''   oauth.AcquireAccessToken(atUrl, "POST", pin);
        ''
        ''   // now, update twitter status using that access token
        ''   var appUrl = "http://api.twitter.com/1/statuses/update.xml?status=Hello";
        ''   var authzHeader = oauth.GenerateAuthzHeader(appUrl, "POST");
        ''   var request = (HttpWebRequest)WebRequest.Create(appUrl);
        ''   request.Method = "POST";
        ''   request.PreAuthenticate = true;
        ''   request.AllowWriteStreamBuffering = true;
        ''   request.Headers.Add("Authorization", authzHeader);
        ''
        ''   using (var response = (HttpWebResponse)request.GetResponse())
        ''   {
        ''     if (response.StatusCode != HttpStatusCode.OK)
        ''       MessageBox.Show("There's been a problem trying to tweet:" +
        ''                       Environment.NewLine +
        ''                       response.StatusDescription);
        ''   }
        ''   </code>
        '' </example>
        ''
        '' <returns>
        ''   a response object that contains the entire text of the response,
        ''   as well as extracted parameters. This method presumes the
        ''   response is query-param encoded. In other words,
        ''   poauth_token=foo&something_else=bar.
        '' </returns>
        Public Function AcquireRequestToken(uri As String, method As String) As OAuthResponse
            NewRequest()
            Dim authzHeader = GetAuthorizationHeader(uri, method)

            ' prepare the token request
            Dim request = DirectCast(System.Net.WebRequest.Create(uri), System.Net.HttpWebRequest)
            request.Headers.Add("Authorization", authzHeader)
            request.Method = method

            Using response = DirectCast(request.GetResponse(), System.Net.HttpWebResponse)
                Using reader = New System.IO.StreamReader(response.GetResponseStream().ToString)
                    Dim r = New OAuthResponse(reader.ReadToEnd())
                    Me("token") = r("oauth_token")

                    ' Sometimes the request_token URL gives us an access token,
                    ' with no user interaction required. Eg, when prior approval
                    ' has already been granted.
                    Try
                        If r("oauth_token_secret") IsNot Nothing Then
                            Me("token_secret") = r("oauth_token_secret")
                        End If
                    Catch
                    End Try
                    Return r
                End Using
            End Using
        End Function


        '' <summary>
        ''   Acquire an access token, from the given URI, using the given
        ''   HTTP method.
        '' </summary>
        ''
        '' <remarks>
        ''   <para>
        ''     To use this method, you must first set the oauth_token to the value
        ''     of the request token.  Eg, oauth["token"] = "whatever".
        ''   </para>
        ''   <para>
        ''     According to the OAuth spec, you need to do this only ONCE per
        ''     application.  In other words, the first time the application
        ''     is run.  The normal oauth workflow is:  (1) get a request token,
        ''     (2) use that to acquire an access token (which requires explicit
        ''     user approval), then (3) using that access token, invoke
        ''     protected services.  The first two steps need to be done only
        ''     once per application.
        ''   </para>
        ''   <para>
        ''     For Twitter, at least, you can cache the access tokens
        ''     indefinitely; Twitter says they never expire.  However, other
        ''     oauth services may not do the same. Also: the user may at any
        ''     time revoke his authorization for your app, in which case you
        ''     need to perform the first 2 steps again.
        ''   </para>
        '' </remarks>
        ''
        '' <seealso cref='AcquireRequestToken'>
        ''
        '' <returns>
        ''   a response object that contains the entire text of the response,
        ''   as well as extracted parameters. This method presumes the
        ''   response is query-param encoded. In other words,
        ''   poauth_token=foo&something_else=bar.
        '' </returns>
        Public Function AcquireAccessToken(uri As String, method As String, pin As String) As OAuthResponse
            NewRequest()
            _params("verifier") = pin

            Dim authzHeader = GetAuthorizationHeader(uri, method)

            ' prepare the token request
            Dim request = DirectCast(System.Net.WebRequest.Create(uri), System.Net.HttpWebRequest)
            request.Headers.Add("Authorization", authzHeader)
            request.Method = method

            Using response = DirectCast(request.GetResponse(), System.Net.HttpWebResponse)
                Using reader = New System.IO.StreamReader(response.GetResponseStream().ToString)
                    Dim r = New OAuthResponse(reader.ReadToEnd())
                    Me("token") = r("oauth_token")
                    Me("token_secret") = r("oauth_token_secret")
                    Return r
                End Using
            End Using
        End Function


        '' <summary>
        ''   Generate a string to be used in an Authorization header in
        ''   an HTTP request.
        '' </summary>
        '' <remarks>
        ''   <para>
        ''     This method assembles the available oauth_ parameters that
        ''     have been set in the Dictionary in this instance, produces
        ''     the signature base (As described by the OAuth spec, RFC 5849),
        ''     signs it, then re-formats the oauth_ parameters into the
        ''     appropriate form, including the oauth_signature value, and
        ''     returns the result.
        ''   </para>
        ''   <para>
        ''     If you pass in a non-null, non-empty realm, this method will
        ''     include the realm='foo' clause in the Authorization header.
        ''   </para>
        '' </remarks>
        ''
        '' <seealso cref='GenerateAuthzHeader'>
        Public Function GenerateCredsHeader(uri As String, method As String, realm As String) As String
            NewRequest()
            Dim authzHeader = GetAuthorizationHeader(uri, method, realm)
            Return authzHeader
        End Function


        '' <summary>
        ''   Generate a string to be used in an Authorization header in
        ''   an HTTP request.
        '' </summary>
        '' <remarks>
        ''   <para>
        ''     This method assembles the available oauth_ parameters that
        ''     have been set in the Dictionary in this instance, produces
        ''     the signature base (As described by the OAuth spec, RFC 5849),
        ''     signs it, then re-formats the oauth_ parameters into the
        ''     appropriate form, including the oauth_signature value, and
        ''     returns the result.
        ''   </para>
        '' </remarks>
        ''
        '' <example>
        ''   <para>
        ''     This example shows how to update the Twitter status
        ''     using the stored consumer key and secret, and a previously
        ''     obtained access token and secret.
        ''   </para>
        ''   <code>
        ''   var oauth = new OAuth.Manager();
        ''   oauth["consumer_key"]    = "~~ your stored consumer key ~~";
        ''   oauth["consumer_secret"] = "~~ your stored consumer secret ~~";
        ''   oauth["token"]           = "~~ your stored access token ~~";
        ''   oauth["token_secret"]    = "~~ your stored access secret ~~";
        ''   var appUrl = "http://api.twitter.com/1/statuses/update.xml?status=Hello";
        ''   var authzHeader = oauth.GenerateAuthzHeader(appUrl, "POST");
        ''   var request = (HttpWebRequest)WebRequest.Create(appUrl);
        ''   request.Method = "POST";
        ''   request.PreAuthenticate = true;
        ''   request.AllowWriteStreamBuffering = true;
        ''   request.Headers.Add("Authorization", authzHeader);
        ''
        ''   using (var response = (HttpWebResponse)request.GetResponse())
        ''   {
        ''     if (response.StatusCode != HttpStatusCode.OK)
        ''       MessageBox.Show("There's been a problem trying to tweet:" +
        ''                       Environment.NewLine +
        ''                       response.StatusDescription);
        ''   }
        ''   </code>
        '' </example>
        '' <seealso cref='GenerateCredsHeader'>
        Public Function GenerateAuthzHeader(uri As String, method As String) As String
            NewRequest()
            Dim authzHeader = GetAuthorizationHeader(uri, method, Nothing)
            Return authzHeader
        End Function

        Private Function GetAuthorizationHeader(uri As String, method As String) As String
            Return GetAuthorizationHeader(uri, method, Nothing)
        End Function

        Private Function GetAuthorizationHeader(uri As String, method As String, realm As String) As String
            If String.IsNullOrEmpty(Me._params("consumer_key")) Then
                Throw New ArgumentNullException("consumer_key")
            End If

            If String.IsNullOrEmpty(Me._params("signature_method")) Then
                Throw New ArgumentNullException("signature_method")
            End If

            Sign(uri, method)

            Dim erp = EncodeRequestParameters(Me._params)
            Return If(([String].IsNullOrEmpty(realm)), Convert.ToString("OAuth ") & erp, [String].Format("OAuth realm=""{0}"", ", realm) & erp)
        End Function


        Private Sub Sign(uri As String, method As String)
            Dim signatureBase = GetSignatureBase(uri, method)
            Dim hash = GetHash()

            Dim dataBuffer As Byte() = System.Text.Encoding.ASCII.GetBytes(signatureBase)
            Dim hashBytes As Byte() = hash.ComputeHash(dataBuffer)

            Me("signature") = Convert.ToBase64String(hashBytes)
        End Sub

        ''' <summary>
        ''' Formats the list of request parameters into "signature base" string as
        ''' defined by RFC 5849.  This will then be MAC'd with a suitable hash.
        ''' </summary>
        Private Function GetSignatureBase(url As String, method As String) As String
            ' normalize the URI
            Dim uri = New Uri(url)
            Dim normUrl = String.Format("{0}://{1}", uri.Scheme, uri.Host)
            If Not ((uri.Scheme = "http" AndAlso uri.Port = 80) OrElse (uri.Scheme = "https" AndAlso uri.Port = 443)) Then
                normUrl = normUrl & String.Format(":{0}", uri.Port)
            End If

            normUrl = normUrl & uri.AbsolutePath

            ' the sigbase starts with the method and the encoded URI
            Dim sb = New System.Text.StringBuilder()
            sb.Append(method).Append("&"c).Append(UrlEncode(normUrl)).Append("&"c)

            ' the parameters follow - all oauth params plus any params on
            ' the uri
            ' each uri may have a distinct set of query params
            Dim p As Dictionary(Of String, String) = ExtractQueryParameters(uri.Query)
            ' add all non-empty params to the "current" params
            For Each p1 As Object In Me._params
                ' Exclude all oauth params that are secret or
                ' signatures; any secrets should be kept to ourselves,
                ' and any existing signature will be invalid.
                If Not [String].IsNullOrEmpty(Me._params(p1.Key)) AndAlso Not p1.Key.EndsWith("_secret") AndAlso Not p1.Key.EndsWith("signature") Then
                    p.Add("oauth_" + p1.Key, p1.Value)
                End If
            Next

            ' concat+format all those params
            Dim sb1 = New System.Text.StringBuilder()

            For Each item As KeyValuePair(Of [String], [String]) In p.OrderBy(Function(x) x.Key)
                ' even "empty" params need to be encoded this way.
                sb1.AppendFormat("{0}={1}&", item.Key, item.Value)
            Next

            ' append the UrlEncoded version of that string to the sigbase
            sb.Append(UrlEncode(sb1.ToString().TrimEnd("&"c)))
            Dim result = sb.ToString()
            Return result
        End Function



        Private Function GetHash() As HashAlgorithm
            If Me("signature_method") <> "HMAC-SHA256" Then
                Throw New NotImplementedException()
            End If

            Dim keystring As String = String.Format("{0}&{1}", UrlEncode(Me("consumer_secret")), UrlEncode(Me("token_secret")))
            Return New HMACSHA256(System.Text.Encoding.ASCII.GetBytes(keystring))

        End Function

#If BROKEN Then
		''' <summary>
		'''   Return the oauth string that can be used in an Authorization
		'''   header. All the oauth terms appear in the string, in alphabetical
		'''   order.
		''' </summary>
		Public Function GetOAuthHeader() As String
			Return EncodeRequestParameters(Me._params)
		End Function
#End If
        Private Shared ReadOnly _epoch As New DateTime(1970, 1, 1, 0, 0, 0,
            0)
        Private _params As Dictionary(Of [String], [String])
        Private ReadOnly _random As Random
    End Class


    ''' <summary>
    '''   A class to hold an OAuth response message.
    ''' </summary>
    Public Class OAuthResponse
        ''' <summary>
        '''   All of the text in the response. This is useful if the app wants
        '''   to do its own parsing.
        ''' </summary>
        Public Property AllText() As String
            Get
                Return m_AllText
            End Get
            Set(value As String)
                m_AllText = value
            End Set
        End Property
        Private m_AllText As String
        Private _params As Dictionary(Of [String], [String])

        ''' <summary>
        '''   a Dictionary of response parameters.
        ''' </summary>
        Default Public ReadOnly Property Item(ix As String) As String
            Get
                Return _params(ix)
            End Get
        End Property


        Public Sub New(alltext__1 As String)
            AllText = alltext__1
            _params = New Dictionary(Of [String], [String])()
            Dim kvpairs = alltext__1.Split("&"c)
            For Each pair As Object In kvpairs
                Dim kv = pair.Split("="c)
                _params.Add(kv(0), kv(1))
                ' expected keys:
                '   oauth_token, oauth_token_secret, user_id, screen_name, etc
            Next
        End Sub
    End Class
End Namespace


