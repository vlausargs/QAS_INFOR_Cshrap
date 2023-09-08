//PROJECT NAME: CSIMaterial
//CLASS NAME: TransferDateChkFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class TransferDateChkFactory
    {
        public ITransferDateChk Create(IApplicationDB appDB)
        {
            var _TransferDateChk = new TransferDateChk(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTransferDateChkExt = timerfactory.Create<ITransferDateChk>(_TransferDateChk);

            return iTransferDateChkExt;
        }
    }
}
