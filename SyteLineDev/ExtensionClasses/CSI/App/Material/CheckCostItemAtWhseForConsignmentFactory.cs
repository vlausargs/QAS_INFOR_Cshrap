//PROJECT NAME: CSIMaterial
//CLASS NAME: CheckCostItemAtWhseForConsignmentFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class CheckCostItemAtWhseForConsignmentFactory
    {
        public ICheckCostItemAtWhseForConsignment Create(IApplicationDB appDB)
        {
            var _CheckCostItemAtWhseForConsignment = new CheckCostItemAtWhseForConsignment(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCheckCostItemAtWhseForConsignmentExt = timerfactory.Create<ICheckCostItemAtWhseForConsignment>(_CheckCostItemAtWhseForConsignment);

            return iCheckCostItemAtWhseForConsignmentExt;
        }
    }
}
