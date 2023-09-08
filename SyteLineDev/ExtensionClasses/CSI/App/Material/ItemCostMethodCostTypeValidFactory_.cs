//PROJECT NAME: CSITest
//CLASS NAME: ItemCostMethodCostTypeValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ItemCostMethodCostTypeValidFactory_
    {
        public IItemCostMethodCostTypeValid_ Create(IApplicationDB appDB)
        {
            var _ItemCostMethodCostTypeValid = new ItemCostMethodCostTypeValid_(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iItemCostMethodCostTypeValidExt = timerfactory.Create<IItemCostMethodCostTypeValid_>(_ItemCostMethodCostTypeValid);

            return iItemCostMethodCostTypeValidExt;
        }
    }
}
