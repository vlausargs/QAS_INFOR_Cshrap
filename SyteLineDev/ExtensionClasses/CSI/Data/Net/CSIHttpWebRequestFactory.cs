using System.Net;

namespace CSI.Data.Net
{
    public class CSIHttpWebRequestFactory : ICSIHttpWebRequestFactory
    {
        public ICSIHttpWebRequest Create(HttpWebRequest httpWebRequest)
        {
            return new CSIHttpWebRequest(httpWebRequest);
        }
    }
}