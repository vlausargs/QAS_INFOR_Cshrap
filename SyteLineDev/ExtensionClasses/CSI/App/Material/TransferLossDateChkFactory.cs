//PROJECT NAME: CSIMaterial
//CLASS NAME: TransferLossDateChkFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class TransferLossDateChkFactory
    {
        public ITransferLossDateChk Create(IApplicationDB appDB)
        {
            var _TransferLossDateChk = new TransferLossDateChk(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTransferLossDateChkExt = timerfactory.Create<ITransferLossDateChk>(_TransferLossDateChk);

            return iTransferLossDateChkExt;
        }
    }
}
