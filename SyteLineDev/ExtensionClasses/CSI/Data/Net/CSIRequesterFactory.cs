using CSI.Serializer;

namespace CSI.Data.Net
{
    public class CSIRequesterFactory : ICSIRequesterFactory
    {
        public ICSIRequester Create()
        {
            var csiHttpWebRequestFactory = new CSIHttpWebRequestFactory();
            var csiWebResponseFactory = new CSIWebResponseFactory();


            return new CSIRequester(csiHttpWebRequestFactory, csiWebResponseFactory);
        }
    }
}