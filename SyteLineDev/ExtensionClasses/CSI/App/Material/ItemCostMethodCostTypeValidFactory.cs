//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemCostMethodCostTypeValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ItemCostMethodCostTypeValidFactory
    {
        public IItemCostMethodCostTypeValid Create(IApplicationDB appDB)
        {
            var _ItemCostMethodCostTypeValid = new ItemCostMethodCostTypeValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iItemCostMethodCostTypeValidExt = timerfactory.Create<IItemCostMethodCostTypeValid>(_ItemCostMethodCostTypeValid);

            return iItemCostMethodCostTypeValidExt;
        }
    }
}
