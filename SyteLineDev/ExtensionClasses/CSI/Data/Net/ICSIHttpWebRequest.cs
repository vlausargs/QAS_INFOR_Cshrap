using System;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace CSI.Data.Net
{
    public interface ICSIHttpWebRequest
    {
        #region Properties

        DateTime Date { get; set; }
        string Expect { get; set; }
        bool HaveResponse { get; }
        WebHeaderCollection Headers { get; set; }
        string Host { get; set; }
        DateTime IfModifiedSince { get; set; }
        bool KeepAlive { get; set; }
        int MaximumAutomaticRedirections { get; set; }
        int MaximumResponseHeadersLength { get; set; }
        string MediaType { get; set; }
        ICredentials Credentials { get; set; }
        string Method { get; set; }
        bool PreAuthenticate { get; set; }
        Version ProtocolVersion { get; set; }
        IWebProxy Proxy { get; set; }
        int ReadWriteTimeout { get; set; }
        string Referer { get; set; }
        Uri RequestUri { get; }
        bool SendChunked { get; set; }
        RemoteCertificateValidationCallback ServerCertificateValidationCallback { get; set; }
        ServicePoint ServicePoint { get; }
        bool SupportsCookieContainer { get; }
        int Timeout { get; set; }
        string TransferEncoding { get; set; }
        bool UnsafeAuthenticatedConnectionSharing { get; set; }
        bool Pipelined { get; set; }
        CookieContainer CookieContainer { get; set; }
        int ContinueTimeout { get; set; }
        HttpContinueDelegate ContinueDelegate { get; set; }
        bool UseDefaultCredentials { get; set; }
        string Accept { get; set; }
        Uri Address { get; }
        bool AllowAutoRedirect { get; set; }
        bool AllowReadStreamBuffering { get; set; }
        bool AllowWriteStreamBuffering { get; set; }
        string UserAgent { get; set; }
        X509CertificateCollection ClientCertificates { get; set; }
        string Connection { get; set; }
        string ConnectionGroupName { get; set; }
        long ContentLength { get; set; }
        string ContentType { get; set; }
        DecompressionMethods AutomaticDecompression { get; set; }

        #endregion

        #region Methods

        void Abort(); // override
        void AddRange(int range);
        void AddRange(int from, int to);
        void AddRange(long range);
        void AddRange(long from, long to);
        void AddRange(string rangeSpecifier, int range);
        void AddRange(string rangeSpecifier, long from, long to);
        void AddRange(string rangeSpecifier, long range);
        void AddRange(string rangeSpecifier, int from, int to);
        IAsyncResult BeginGetRequestStream(AsyncCallback callback, object state); // override
        IAsyncResult BeginGetResponse(AsyncCallback callback, object state);      // override
        Stream EndGetRequestStream(IAsyncResult asyncResult, out TransportContext context);
        Stream EndGetRequestStream(IAsyncResult asyncResult); // override
        WebResponse EndGetResponse(IAsyncResult asyncResult); // override
        Stream GetRequestStream();                            // override
        Stream GetRequestStream(out TransportContext context);
        WebResponse GetResponse(); // override

        #endregion
    }
}