Option Strict On
Option Explicit On

Imports System
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description
Imports System.ServiceModel.Dispatcher
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security

''Imports System.Web.HttpContext




Namespace IPFAlertService
    Public Class AlertServiceClient

        Public Sub New(ByVal portalURL As String)
            _portalURL = portalURL
            Dim MAXSIZE As Integer = Int32.MaxValue
            Dim binding As BasicHttpBinding = New BasicHttpBinding With {
                .MessageEncoding = WSMessageEncoding.Text,
                .MaxBufferSize = MAXSIZE,
                .MaxReceivedMessageSize = MAXSIZE,
                .SendTimeout = New TimeSpan(0, 10, 0),
                .ReceiveTimeout = New TimeSpan(0, 10, 0)
            }

            Dim readerQuotasDictionary As System.Xml.XmlDictionaryReaderQuotas = New System.Xml.XmlDictionaryReaderQuotas With {
                .MaxStringContentLength = MAXSIZE,
                .MaxArrayLength = MAXSIZE,
                .MaxDepth = MAXSIZE,
                .MaxNameTableCharCount = MAXSIZE
            }
            binding.ReaderQuotas = readerQuotasDictionary

            Dim bindingSecurity As BasicHttpSecurity = New BasicHttpSecurity()
            If (portalURL.StartsWith("https")) Then
                bindingSecurity.Mode = BasicHttpSecurityMode.Transport
            Else
                bindingSecurity.Mode = BasicHttpSecurityMode.TransportCredentialOnly
            End If

            Dim bindingTransportSecurity As HttpTransportSecurity = New HttpTransportSecurity With {
                .ClientCredentialType = HttpClientCredentialType.Windows
            }
            bindingSecurity.Transport = bindingTransportSecurity
            binding.Security = bindingSecurity

            Try

                Dim endPoint As EndpointAddress = New EndpointAddress(New Uri(portalURL))

                _client = New IPFAlertService.AlertServiceClient.AlertServiceClient(binding, endPoint)
                _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Identification
                _client.ChannelFactory.Credentials.Windows.ClientCredential = System.Net.CredentialCache.DefaultNetworkCredentials
                _client.Endpoint.Behaviors.Add(New OAuthEndPointBehaviorInspector(New Uri(portalURL)))

            Catch ex As Exception
                Throw New Exception("Unable to connect")
            End Try
        End Sub

        Public Sub AlertUser(ByVal userId As String, ByRef e As IPFEvent)
            _client.AlertUser_Event(userId, e)
        End Sub
        Public Sub AlertUser(ByVal userId As String, ByVal eventName As String)
            _client.AlertUser_EventName(userId, eventName)
        End Sub
        Public Sub AlertUser(ByVal userId As String, ByRef e As IPFEvent, ByVal LCID As Integer)
            _client.AlertUser_Event_LCID(userId, e, LCID)
        End Sub
        Public Sub AlertUser(ByVal userId As String, ByVal eventName As String, ByVal LCID As Integer)
            _client.AlertUser_EventName_LCID(userId, eventName, LCID)
        End Sub

        Private ReadOnly _portalURL As String
        Private _client As AlertServiceClient


        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"), _
         System.ServiceModel.ServiceContractAttribute([Namespace]:="IPFAlertService", ConfigurationName:="AlertServiceReference.IAlertService")> _
        Private Interface IAlertService

            <System.ServiceModel.OperationContractAttribute(Action:="IPFAlertService/IAlertService/AlertUser_Event", ReplyAction:="IPFAlertService/IAlertService/AlertUser_EventResponse")> _
            Sub AlertUser_Event(ByVal userId As String, ByVal e As IPFAlertService.IPFEvent)

            <System.ServiceModel.OperationContractAttribute(Action:="IPFAlertService/IAlertService/AlertUser_EventName", ReplyAction:="IPFAlertService/IAlertService/AlertUser_EventNameResponse")> _
            Sub AlertUser_EventName(ByVal userId As String, ByVal eventName As String)

            <System.ServiceModel.OperationContractAttribute(Action:="IPFAlertService/IAlertService/AlertUser_Event_LCID", ReplyAction:="IPFAlertService/IAlertService/AlertUser_Event_LCIDResponse")> _
            Sub AlertUser_Event_LCID(ByVal userId As String, ByVal e As IPFAlertService.IPFEvent, ByVal LCID As Integer)

            <System.ServiceModel.OperationContractAttribute(Action:="IPFAlertService/IAlertService/AlertUser_EventName_LCID", ReplyAction:="IPFAlertService/IAlertService/AlertUser_EventName_LCIDResponse")> _
            Sub AlertUser_EventName_LCID(ByVal userId As String, ByVal eventName As String, ByVal LCID As Integer)
        End Interface

        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")> _
        Private Interface IAlertServiceChannel
            Inherits IPFAlertService.AlertServiceClient.IAlertService, System.ServiceModel.IClientChannel
        End Interface

        <System.Diagnostics.DebuggerStepThroughAttribute(), _
         System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")> _
        Partial Private Class AlertServiceClient
            Inherits System.ServiceModel.ClientBase(Of IPFAlertService.AlertServiceClient.IAlertService)
            Implements IPFAlertService.AlertServiceClient.IAlertService


            Public Sub New()
                MyBase.New()
            End Sub

            Public Sub New(ByVal endpointConfigurationName As String)
                MyBase.New(endpointConfigurationName)
            End Sub

            Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
                MyBase.New(endpointConfigurationName, remoteAddress)
            End Sub

            Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
                MyBase.New(endpointConfigurationName, remoteAddress)
            End Sub

            Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
                MyBase.New(binding, remoteAddress)
            End Sub

            Public Sub AlertUser_Event(ByVal userId As String, ByVal e As IPFAlertService.IPFEvent) Implements IPFAlertService.AlertServiceClient.IAlertService.AlertUser_Event
                MyBase.Channel.AlertUser_Event(userId, e)
            End Sub


            Public Sub AlertUser_EventName(ByVal userId As String, ByVal eventName As String) Implements IPFAlertService.AlertServiceClient.IAlertService.AlertUser_EventName
                MyBase.Channel.AlertUser_EventName(userId, eventName)
            End Sub

            Public Sub AlertUser_Event_LCID(ByVal userId As String, ByVal e As IPFAlertService.IPFEvent, ByVal LCID As Integer) Implements IPFAlertService.AlertServiceClient.IAlertService.AlertUser_Event_LCID
                MyBase.Channel.AlertUser_Event_LCID(userId, e, LCID)
            End Sub

            Public Sub AlertUser_EventName_LCID(ByVal userId As String, ByVal eventName As String, ByVal LCID As Integer) Implements IPFAlertService.AlertServiceClient.IAlertService.AlertUser_EventName_LCID
                MyBase.Channel.AlertUser_EventName_LCID(userId, eventName, LCID)
            End Sub




        End Class
    End Class
    <System.Diagnostics.DebuggerStepThroughAttribute(), _
System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0"), _
System.Runtime.Serialization.DataContractAttribute(Name:="IPFEvent", [Namespace]:="IPFAlertService"), _
System.SerializableAttribute()> _
    Partial Public Class IPFEvent
        Inherits Object
        Implements System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged




        <System.NonSerializedAttribute()> _
        Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject

        <System.Runtime.Serialization.OptionalFieldAttribute()> _
        Private NameField As String

        <System.Runtime.Serialization.OptionalFieldAttribute()> _
        Private VariablesField As System.Collections.Generic.Dictionary(Of String, Object)

        Public Sub New()
            Variables = New System.Collections.Generic.Dictionary(Of String, Object)
        End Sub




        <Global.System.ComponentModel.BrowsableAttribute(False)> _
        Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set(ByVal value As System.Runtime.Serialization.ExtensionDataObject)
                Me.extensionDataField = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute()> _
        Public Property Name() As String
            Get
                Return Me.NameField
            End Get
            Set(ByVal value As String)
                If (Object.ReferenceEquals(Me.NameField, value) <> True) Then
                    Me.NameField = value
                    Me.RaisePropertyChanged("Name")
                End If
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute()> _
        Public Property Variables() As System.Collections.Generic.Dictionary(Of String, Object)
            Get
                Return Me.VariablesField
            End Get
            Set(ByVal value As System.Collections.Generic.Dictionary(Of String, Object))
                If (Object.ReferenceEquals(Me.VariablesField, value) <> True) Then
                    Me.VariablesField = value
                    Me.RaisePropertyChanged("Variables")
                End If
            End Set
        End Property

        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub


        'Public Sub AfterReceiveReply(ByRef reply As Message, correlationState As Object) Implements IClientMessageInspector.AfterReceiveReply
        '    Console.WriteLine("IClientMessageInspector.AfterReceiveReply called.")
        '    Console.WriteLine("Message: {0}", reply.ToString())
        'End Sub

        'Public Function BeforeSendRequest(ByRef request As Message, channel As IClientChannel) As Object Implements IClientMessageInspector.BeforeSendRequest
        '    Console.WriteLine("IClientMessageInspector.BeforeSendRequest called.")
        '    Return Nothing
        'End Function
    End Class
    Public Class OAuthEndPointBehaviorInspector
        Implements IEndpointBehavior, IClientMessageInspector

        Property UriStr As Uri

        Sub New(ByVal puri As Uri)
            Me.UriStr = puri
        End Sub

        Public Sub AddBindingParameters(endpoint As ServiceEndpoint, bindingParameters As BindingParameterCollection) Implements IEndpointBehavior.AddBindingParameters
        End Sub

        Public Sub ApplyClientBehavior(endpoint As ServiceEndpoint, clientRuntime As ClientRuntime) Implements IEndpointBehavior.ApplyClientBehavior
            clientRuntime.MessageInspectors.Add(New CustomClientMessageInspector(Me.UriStr))
        End Sub

        Public Sub ApplyDispatchBehavior(endpoint As ServiceEndpoint, endpointDispatcher As EndpointDispatcher) Implements IEndpointBehavior.ApplyDispatchBehavior
        End Sub

        Public Sub Validate(endpoint As ServiceEndpoint) Implements IEndpointBehavior.Validate
        End Sub

        Public Sub AfterReceiveReply(ByRef reply As Message, correlationState As Object) Implements IClientMessageInspector.AfterReceiveReply
        End Sub

        Public Function BeforeSendRequest(ByRef request As Message, channel As IClientChannel) As Object Implements IClientMessageInspector.BeforeSendRequest
            Dim val As Integer = 10
            Return Nothing
        End Function
    End Class
    Public Class CustomClientMessageInspector
        Implements IClientMessageInspector

        Property UriStr As Uri

        Sub New(ByVal puri As Uri)
            Me.UriStr = puri
        End Sub
        Public Sub AfterReceiveReply(ByRef reply As Message, correlationState As Object) Implements IClientMessageInspector.AfterReceiveReply
        End Sub

        Public Function BeforeSendRequest(ByRef request As Message, channel As IClientChannel) As Object Implements IClientMessageInspector.BeforeSendRequest
            Dim httpRequest As HttpRequestMessageProperty

            If Not request.Properties.ContainsKey(HttpRequestMessageProperty.Name) Then
                httpRequest = New HttpRequestMessageProperty()
                request.Properties.Add(HttpRequestMessageProperty.Name, httpRequest)
            Else
                httpRequest = TryCast(request.Properties(HttpRequestMessageProperty.Name), HttpRequestMessageProperty)
            End If

            'Dim oauth = New OAuthManager()
            'oauth("consumer_key") = "CloudSuitePortal"
            'oauth("consumer_secret") = "IPF$uper$ecret1"
            'Dim authzHeader = oauth.GenerateAuthzHeader([String].Format("{0}:{1}", Uri.Host, Uri.Port), "POST")
            Dim _lsportalPars As New SLPortalParms()
            Dim oAuthKey As String = String.Empty
            Dim oAuthSecret As String = String.Empty
            _lsportalPars.GetOAUTHKeyandSecret(Me.UriStr, oAuthKey, oAuthSecret)


            '' OAUTH calls when keys are present
            '' otherwise Windows authentication will be used

            If (Not String.IsNullOrEmpty(oAuthKey) And Not String.IsNullOrEmpty(oAuthSecret)) Then
                Dim oauth As New OAuthManager()
                oauth("consumer_key") = oAuthKey
                oauth("consumer_secret") = oAuthSecret
                Dim authzHeader As String = oauth.GenerateAuthzHeader(Me.UriStr.ToString(), "POST")
                httpRequest.Headers.Add("Authorization", authzHeader)

            End If
            Return Nothing
        End Function
    End Class

End Namespace
