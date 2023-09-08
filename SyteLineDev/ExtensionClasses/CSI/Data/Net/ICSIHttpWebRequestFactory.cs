using System.Net;

namespace CSI.Data.Net
{
    public interface ICSIHttpWebRequestFactory
    {
        ICSIHttpWebRequest Create(HttpWebRequest httpWebRequest);
    }
}