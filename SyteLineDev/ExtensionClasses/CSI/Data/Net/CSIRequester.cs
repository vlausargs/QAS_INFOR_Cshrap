using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using CSI.Serializer;

namespace CSI.Data.Net
{
    public class CSIRequester : ICSIRequester
    {
        private readonly ICSIHttpWebRequestFactory _csiHttpWebRequestFactory;
        private readonly ICSIWebResponseFactory _csiWebResponseFactory;

        public CSIRequester(ICSIHttpWebRequestFactory csiHttpWebRequestFactory, ICSIWebResponseFactory csiWebResponseFactory)
        {
            _csiHttpWebRequestFactory = csiHttpWebRequestFactory;
            _csiWebResponseFactory = csiWebResponseFactory;
        }

        public ICSIHttpWebRequest Create(
            string requestUriString,
            string method,
            string contentType,
            string accept)
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(requestUriString);
            httpWebRequest.Method = method;
            httpWebRequest.Accept = accept;
            httpWebRequest.ContentType = contentType;

            return _csiHttpWebRequestFactory.Create(httpWebRequest);
        }

        public ICSIWebResponse Call(ICSIHttpWebRequest httpWebRequest, string requestBody)
        {
            if (string.IsNullOrWhiteSpace(requestBody) || httpWebRequest.Method == "GET")
                return
                    _csiWebResponseFactory.Create(httpWebRequest.GetResponse());
            var byteVersion = Encoding.ASCII.GetBytes(requestBody);
            var contentLength = byteVersion.Length;
            var stream = httpWebRequest.GetRequestStream();
            stream.Write(byteVersion, 0, byteVersion.Length);
            stream.Close();

            return _csiWebResponseFactory.Create(httpWebRequest.GetResponse());
        }
    }
}