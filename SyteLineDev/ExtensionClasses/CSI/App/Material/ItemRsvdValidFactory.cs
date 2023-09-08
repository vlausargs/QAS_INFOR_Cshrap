//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemRsvdValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ItemRsvdValidFactory
    {
        public IItemRsvdValid Create(IApplicationDB appDB)
        {
            var _ItemRsvdValid = new ItemRsvdValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iItemRsvdValidExt = timerfactory.Create<IItemRsvdValid>(_ItemRsvdValid);

            return iItemRsvdValidExt;
        }
    }
}
