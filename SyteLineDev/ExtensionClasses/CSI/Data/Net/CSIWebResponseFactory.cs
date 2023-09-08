using System.Net;

namespace CSI.Data.Net
{
    public class CSIWebResponseFactory : ICSIWebResponseFactory
    {
        public ICSIWebResponse Create(WebResponse webResponse)
        {
            return new CSIWebResponse(webResponse);
        }
    }
}