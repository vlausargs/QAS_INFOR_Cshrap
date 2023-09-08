//PROJECT NAME: CSIProduct
//CLASS NAME: WcEopCostFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class WcEopCostFactory
    {
        public IWcEopCost Create(IApplicationDB appDB)
        {
            var _WcEopCost = new Production.WcEopCost(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iWcEopCostExt = timerfactory.Create<Production.IWcEopCost>(_WcEopCost);

            return iWcEopCostExt;
        }
    }
}
