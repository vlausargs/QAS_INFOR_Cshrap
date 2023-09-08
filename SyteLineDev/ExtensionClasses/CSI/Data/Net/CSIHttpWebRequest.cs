using System;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace CSI.Data.Net
{
    public class CSIHttpWebRequest : ICSIHttpWebRequest
    {
        private readonly HttpWebRequest _httpWebRequest;

        public CSIHttpWebRequest(HttpWebRequest httpWebRequest)
        {
            _httpWebRequest = httpWebRequest;
        }

        #region Properties

        public ServicePoint ServicePoint => _httpWebRequest.ServicePoint;

        public bool SupportsCookieContainer => _httpWebRequest.SupportsCookieContainer;

        public bool HaveResponse => _httpWebRequest.HaveResponse;

        public Uri RequestUri => _httpWebRequest.RequestUri;

        public Uri Address => _httpWebRequest.Address;

        public DateTime Date
        {
            get => _httpWebRequest.Date;
            set => _httpWebRequest.Date = value;
        }

        public string Expect
        {
            get => _httpWebRequest.Expect;
            set => _httpWebRequest.Expect = value;
        }

        public WebHeaderCollection Headers
        {
            get => _httpWebRequest.Headers;
            set => _httpWebRequest.Headers = value;
        }

        public string Host
        {
            get => _httpWebRequest.Host;
            set => _httpWebRequest.Host = value;
        }

        public DateTime IfModifiedSince
        {
            get => _httpWebRequest.IfModifiedSince;
            set => _httpWebRequest.IfModifiedSince = value;
        }

        public bool KeepAlive
        {
            get => _httpWebRequest.KeepAlive;
            set => _httpWebRequest.KeepAlive = value;
        }

        public int MaximumAutomaticRedirections
        {
            get => _httpWebRequest.MaximumAutomaticRedirections;
            set => _httpWebRequest.MaximumAutomaticRedirections = value;
        }

        public int MaximumResponseHeadersLength
        {
            get => _httpWebRequest.MaximumResponseHeadersLength;
            set => _httpWebRequest.MaximumResponseHeadersLength = value;
        }

        public string MediaType
        {
            get => _httpWebRequest.MediaType;
            set => _httpWebRequest.MediaType = value;
        }

        public ICredentials Credentials
        {
            get => _httpWebRequest.Credentials;
            set => _httpWebRequest.Credentials = value;
        }

        public string Method
        {
            get => _httpWebRequest.Method;
            set => _httpWebRequest.Method = value;
        }

        public bool PreAuthenticate
        {
            get => _httpWebRequest.PreAuthenticate;
            set => _httpWebRequest.PreAuthenticate = value;
        }

        public Version ProtocolVersion
        {
            get => _httpWebRequest.ProtocolVersion;
            set => _httpWebRequest.ProtocolVersion = value;
        }

        public IWebProxy Proxy
        {
            get => _httpWebRequest.Proxy;
            set => _httpWebRequest.Proxy = value;
        }

        public int ReadWriteTimeout
        {
            get => _httpWebRequest.ReadWriteTimeout;
            set => _httpWebRequest.ReadWriteTimeout = value;
        }

        public string Referer
        {
            get => _httpWebRequest.Referer;
            set => _httpWebRequest.Referer = value;
        }

        public bool SendChunked
        {
            get => _httpWebRequest.SendChunked;
            set => _httpWebRequest.SendChunked = value;
        }

        public RemoteCertificateValidationCallback ServerCertificateValidationCallback
        {
            get => _httpWebRequest.ServerCertificateValidationCallback;
            set => _httpWebRequest.ServerCertificateValidationCallback = value;
        }

        public int Timeout
        {
            get => _httpWebRequest.Timeout;
            set => _httpWebRequest.Timeout = value;
        }

        public string TransferEncoding
        {
            get => _httpWebRequest.TransferEncoding;
            set => _httpWebRequest.TransferEncoding = value;
        }

        public bool UnsafeAuthenticatedConnectionSharing
        {
            get => _httpWebRequest.UnsafeAuthenticatedConnectionSharing;
            set => _httpWebRequest.UnsafeAuthenticatedConnectionSharing = value;
        }

        public bool Pipelined
        {
            get => _httpWebRequest.Pipelined;
            set => _httpWebRequest.Pipelined = value;
        }

        public CookieContainer CookieContainer
        {
            get => _httpWebRequest.CookieContainer;
            set => _httpWebRequest.CookieContainer = value;
        }

        public int ContinueTimeout
        {
            get => _httpWebRequest.ContinueTimeout;
            set => _httpWebRequest.ContinueTimeout = value;
        }

        public HttpContinueDelegate ContinueDelegate
        {
            get => _httpWebRequest.ContinueDelegate;
            set => _httpWebRequest.ContinueDelegate = value;
        }

        public bool UseDefaultCredentials
        {
            get => _httpWebRequest.UseDefaultCredentials;
            set => _httpWebRequest.UseDefaultCredentials = value;
        }

        public string Accept
        {
            get => _httpWebRequest.Accept;
            set => _httpWebRequest.Accept = value;
        }

        public bool AllowAutoRedirect
        {
            get => _httpWebRequest.AllowAutoRedirect;
            set => _httpWebRequest.AllowAutoRedirect = value;
        }

        public bool AllowReadStreamBuffering
        {
            get => _httpWebRequest.AllowReadStreamBuffering;
            set => _httpWebRequest.AllowReadStreamBuffering = value;
        }

        public bool AllowWriteStreamBuffering
        {
            get => _httpWebRequest.AllowWriteStreamBuffering;
            set => _httpWebRequest.AllowWriteStreamBuffering = value;
        }

        public string UserAgent
        {
            get => _httpWebRequest.UserAgent;
            set => _httpWebRequest.UserAgent = value;
        }

        public X509CertificateCollection ClientCertificates
        {
            get => _httpWebRequest.ClientCertificates;
            set => _httpWebRequest.ClientCertificates = value;
        }

        public string Connection
        {
            get => _httpWebRequest.Connection;
            set => _httpWebRequest.Connection = value;
        }

        public string ConnectionGroupName
        {
            get => _httpWebRequest.ConnectionGroupName;
            set => _httpWebRequest.ConnectionGroupName = value;
        }

        public long ContentLength
        {
            get => _httpWebRequest.ContentLength;
            set => _httpWebRequest.ContentLength = value;
        }

        public string ContentType
        {
            get => _httpWebRequest.ContentType;
            set => _httpWebRequest.ContentType = value;
        }

        public DecompressionMethods AutomaticDecompression
        {
            get => _httpWebRequest.AutomaticDecompression;
            set => _httpWebRequest.AutomaticDecompression = value;
        }

        #endregion

        #region Methods

        public void Abort()
        {
            _httpWebRequest.Abort();
        }

        public void AddRange(int range)
        {
            _httpWebRequest.AddRange(range);
        }

        public void AddRange(int from, int to)
        {
            _httpWebRequest.AddRange(from, to);
        }

        public void AddRange(long range)
        {
            _httpWebRequest.AddRange(range);
        }

        public void AddRange(long from, long to)
        {
            _httpWebRequest.AddRange(from, to);
        }

        public void AddRange(string rangeSpecifier, int range)
        {
            _httpWebRequest.AddRange(rangeSpecifier, range);
        }

        public void AddRange(string rangeSpecifier, long from, long to)
        {
            _httpWebRequest.AddRange(rangeSpecifier, from, to);
        }

        public void AddRange(string rangeSpecifier, long range)
        {
            _httpWebRequest.AddRange(rangeSpecifier, range);
        }

        public void AddRange(string rangeSpecifier, int from, int to)
        {
            _httpWebRequest.AddRange(rangeSpecifier, from, to);
        }

        public IAsyncResult BeginGetRequestStream(AsyncCallback callback, object state)
        {
            return _httpWebRequest.BeginGetRequestStream(callback, state);
        }

        public IAsyncResult BeginGetResponse(AsyncCallback callback, object state)
        {
            return _httpWebRequest.BeginGetResponse(callback, state);
        }

        public Stream EndGetRequestStream(IAsyncResult asyncResult, out TransportContext context)
        {
            return _httpWebRequest.EndGetRequestStream(asyncResult, out context);
        }

        public Stream EndGetRequestStream(IAsyncResult asyncResult)
        {
            return _httpWebRequest.EndGetRequestStream(asyncResult);
        }

        public WebResponse EndGetResponse(IAsyncResult asyncResult)
        {
            return _httpWebRequest.EndGetResponse(asyncResult);
        }

        public Stream GetRequestStream()
        {
            return _httpWebRequest.GetRequestStream();
        }

        public Stream GetRequestStream(out TransportContext context)
        {
            return _httpWebRequest.GetRequestStream(out context);
        }

        public WebResponse GetResponse()
        {
            return _httpWebRequest.GetResponse();
        }

        #endregion
    }
}