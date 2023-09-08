//PROJECT NAME: CSIProduct
//CLASS NAME: PsitemReleaseWoRoutingFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class PsitemReleaseWoRoutingFactory
    {
        public IPsitemReleaseWoRouting Create(IApplicationDB appDB)
        {
            var _PsitemReleaseWoRouting = new PsitemReleaseWoRouting(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPsitemReleaseWoRoutingExt = timerfactory.Create<IPsitemReleaseWoRouting>(_PsitemReleaseWoRouting);

            return iPsitemReleaseWoRoutingExt;
        }
    }
}
