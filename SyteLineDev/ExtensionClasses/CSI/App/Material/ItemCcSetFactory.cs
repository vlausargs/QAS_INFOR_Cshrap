//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemCcSetFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ItemCcSetFactory
    {
        public IItemCcSet Create(IApplicationDB appDB)
        {
            var _ItemCcSet = new ItemCcSet(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iItemCcSetExt = timerfactory.Create<IItemCcSet>(_ItemCcSet);

            return iItemCcSetExt;
        }
    }
}
