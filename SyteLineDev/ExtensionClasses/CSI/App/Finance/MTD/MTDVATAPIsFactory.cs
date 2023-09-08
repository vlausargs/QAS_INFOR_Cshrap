using CSI.Data;
using CSI.Data.Net;
using CSI.Serializer;

namespace CSI.Finance.MTD
{
    public class MTDVATAPIsFactory
    {
        public IMTDVATAPIs Create(IMsgApp msgApp)
        {
            var csiRequester = new CSIRequesterFactory().Create();
            var fraudPreventionHeadersGenerator = new FraudPreventionHeadersGenerator(csiRequester, msgApp);
            var mtdAPIFailedMessage = new MTDAPIFailedMessageFactory().Create();

            var mtdVATAPIs = new MTDVATAPIs(csiRequester, fraudPreventionHeadersGenerator, mtdAPIFailedMessage);

            var timerFactory = new CSI.Data.Metric.TimerFactory();
            return timerFactory.Create<IMTDVATAPIs>(mtdVATAPIs);
        }
    }
}