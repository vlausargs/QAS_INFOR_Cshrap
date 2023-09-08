//PROJECT NAME: CSIMaterial
//CLASS NAME: ShipTransferProcessASNFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ShipTransferProcessASNFactory
    {
        public IShipTransferProcessASN Create(IApplicationDB appDB)
        {
            var _ShipTransferProcessASN = new ShipTransferProcessASN(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iShipTransferProcessASNExt = timerfactory.Create<IShipTransferProcessASN>(_ShipTransferProcessASN);

            return iShipTransferProcessASNExt;
        }
    }
}
