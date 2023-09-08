//PROJECT NAME: BusInterface
//CLASS NAME: InitESBInventoryCountFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
    public class InitESBInventoryCountFactory
    {
        public IInitESBInventoryCount Create(IApplicationDB appDB)
        {
            var _InitESBInventoryCount = new BusInterface.InitESBInventoryCount(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iInitESBInventoryCountExt = timerfactory.Create<BusInterface.IInitESBInventoryCount>(_InitESBInventoryCount);

            return iInitESBInventoryCountExt;
        }
    }
}
