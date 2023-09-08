//PROJECT NAME: CSIProduct
//CLASS NAME: WcEopCostLasttranFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class WcEopCostLasttranFactory
    {
        public IWcEopCostLasttran Create(IApplicationDB appDB)
        {
            var _WcEopCostLasttran = new Production.WcEopCostLasttran(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iWcEopCostLasttranExt = timerfactory.Create<Production.IWcEopCostLasttran>(_WcEopCostLasttran);

            return iWcEopCostLasttranExt;
        }
    }
}
