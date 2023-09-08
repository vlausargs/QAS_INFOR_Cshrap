//PROJECT NAME: CSIMaterial
//CLASS NAME: MrpInitTransferOrderFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class MrpInitTransferOrderFactory
    {
        public IMrpInitTransferOrder Create(IApplicationDB appDB)
        {
            var _MrpInitTransferOrder = new MrpInitTransferOrder(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iMrpInitTransferOrderExt = timerfactory.Create<IMrpInitTransferOrder>(_MrpInitTransferOrder);

            return iMrpInitTransferOrderExt;
        }
    }
}
 