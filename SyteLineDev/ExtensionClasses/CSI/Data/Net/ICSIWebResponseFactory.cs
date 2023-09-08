using System.Net;

namespace CSI.Data.Net
{
    public interface ICSIWebResponseFactory
    {
        ICSIWebResponse Create(WebResponse webResponse);
    }
}