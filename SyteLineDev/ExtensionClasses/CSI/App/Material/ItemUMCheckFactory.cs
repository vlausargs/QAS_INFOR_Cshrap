//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemUMCheckFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ItemUMCheckFactory
    {
        public IItemUMCheck Create(IApplicationDB appDB)
        {
            var _ItemUMCheck = new ItemUMCheck(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iItemUMCheckExt = timerfactory.Create<IItemUMCheck>(_ItemUMCheck);

            return iItemUMCheckExt;
        }
    }
}
