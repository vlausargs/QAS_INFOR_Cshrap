using System;
using System.IO;
using System.Net;

namespace CSI.Data.Net
{
    public class CSIWebResponse : ICSIWebResponse
    {
        private readonly WebResponse _webResponse;

        public CSIWebResponse(WebResponse webResponse)
        {
            this._webResponse = webResponse;
        }

        public WebHeaderCollection Headers => _webResponse.Headers;
        public bool IsFromCache => _webResponse.IsFromCache;
        public bool IsMutuallyAuthenticated => _webResponse.IsMutuallyAuthenticated;
        public Uri ResponseUri => _webResponse.ResponseUri;
        public bool SupportsHeaders => _webResponse.SupportsHeaders;

        public long ContentLength
        {
            get => _webResponse.ContentLength;
            set => _webResponse.ContentLength = value;
        }

        public string ContentType
        {
            get => _webResponse.ContentType;
            set => _webResponse.ContentType = value;
        }

        public void Close()
        {
            _webResponse.Close();
        }

        public void Dispose()
        {
            _webResponse.Dispose();
        }

        public Stream GetResponseStream()
        {
            return _webResponse.GetResponseStream();
        }
    }
}