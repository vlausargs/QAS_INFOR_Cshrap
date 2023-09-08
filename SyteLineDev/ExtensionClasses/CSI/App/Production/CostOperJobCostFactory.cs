//PROJECT NAME: Production
//CLASS NAME: CostOperJobCostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
    public class CostOperJobCostFactory
    {
        public ICostOperJobCost Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _CostOperJobCost = new Production.CostOperJobCost(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCostOperJobCostExt = timerfactory.Create<Production.ICostOperJobCost>(_CostOperJobCost);

            return iCostOperJobCostExt;
        }
    }
}
