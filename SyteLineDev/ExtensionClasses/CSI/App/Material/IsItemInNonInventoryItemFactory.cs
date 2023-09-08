//PROJECT NAME: CSIMaterial
//CLASS NAME: IsItemInNonInventoryItemFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class IsItemInNonInventoryItemFactory
    {
        public IIsItemInNonInventoryItem Create(IApplicationDB appDB)
        {
            var _IsItemInNonInventoryItem = new IsItemInNonInventoryItem(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iIsItemInNonInventoryItemExt = timerfactory.Create<IIsItemInNonInventoryItem>(_IsItemInNonInventoryItem);

            return iIsItemInNonInventoryItemExt;
        }
    }
}
