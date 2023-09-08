//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemNewFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ItemNewFactory
    {
        public IItemNew Create(IApplicationDB appDB)
        {
            var _ItemNew = new ItemNew(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iItemNewExt = timerfactory.Create<IItemNew>(_ItemNew);

            return iItemNewExt;
        }
    }
}
