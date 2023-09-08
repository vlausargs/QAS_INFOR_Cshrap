//PROJECT NAME: Material
//CLASS NAME: ItemUMValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
    public class ItemUMValidFactory
    {
        public IItemUMValid Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var _ItemUMValid = new Material.ItemUMValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iItemUMValidExt = timerfactory.Create<Material.IItemUMValid>(_ItemUMValid);

            return iItemUMValidExt;
        }
    }
}
