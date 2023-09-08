using CSI.Data;
using CSI.Data.Net;

namespace CSI.Finance.MTD
{
    public class FraudPreventionHeadersGeneratorFactory
    {
        public IFraudPreventionHeadersGenerator Create(ICSIRequester csiRequester, IMsgApp msgApp)
        {
            var fraudPreventionHeadersGenerator = new FraudPreventionHeadersGenerator(csiRequester, msgApp);

            var timerFactory = new CSI.Data.Metric.TimerFactory();
            return timerFactory.Create<IFraudPreventionHeadersGenerator>(fraudPreventionHeadersGenerator);
        }
    }
}