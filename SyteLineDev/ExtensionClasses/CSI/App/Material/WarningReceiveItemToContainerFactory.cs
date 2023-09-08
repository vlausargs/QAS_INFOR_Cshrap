//PROJECT NAME: CSIMaterial
//CLASS NAME: WarningReceiveItemToContainerFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class WarningReceiveItemToContainerFactory
    {
        public IWarningReceiveItemToContainer Create(IApplicationDB appDB)
        {
            var _WarningReceiveItemToContainer = new WarningReceiveItemToContainer(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iWarningReceiveItemToContainerExt = timerfactory.Create<IWarningReceiveItemToContainer>(_WarningReceiveItemToContainer);

            return iWarningReceiveItemToContainerExt;
        }
    }
}
