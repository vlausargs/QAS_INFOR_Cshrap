//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemLotExistsFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ItemLotExistsFactory
    {
        public IItemLotExists Create(IApplicationDB appDB)
        {
            var _ItemLotExists = new ItemLotExists(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iItemLotExistsExt = timerfactory.Create<IItemLotExists>(_ItemLotExists);

            return iItemLotExistsExt;
        }
    }
}
