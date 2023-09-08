using CSI.Data;
using CSI.Data.Net;

namespace CSI.Finance.MTD
{
    public class MTDOAuthFactory
    {
        public IMTDOAuth Create(IMsgApp msgApp)
        {
            var csiRequester = new CSIRequesterFactory().Create();
            var fraudPreventionHeadersGenerator = new FraudPreventionHeadersGenerator(csiRequester, msgApp);
            var mtdAPIFailedMessage = new MTDAPIFailedMessageFactory().Create();

            var mtdOAuth = new MTDOAuth(csiRequester, fraudPreventionHeadersGenerator, mtdAPIFailedMessage);

            var timerFactory = new CSI.Data.Metric.TimerFactory();
            return timerFactory.Create<IMTDOAuth>(mtdOAuth);
        }
    }
}