using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CSI.Data.Net
{
    public interface ICSIRequester
    {
        ICSIHttpWebRequest Create(
            string requestUriString,
            string method,
            string contentType,
            string accept);

        ICSIWebResponse Call(ICSIHttpWebRequest httpWebRequest, string requestBody);
    }
}