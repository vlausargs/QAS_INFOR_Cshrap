//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemLifoSnapFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ItemLifoSnapFactory
    {
        public IItemLifoSnap Create(IApplicationDB appDB)
        {
            var _ItemLifoSnap = new ItemLifoSnap(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iItemLifoSnapExt = timerfactory.Create<IItemLifoSnap>(_ItemLifoSnap);

            return iItemLifoSnapExt;
        }
    }
}
