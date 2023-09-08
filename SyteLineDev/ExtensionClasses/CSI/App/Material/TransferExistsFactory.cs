//PROJECT NAME: CSIMaterial
//CLASS NAME: TransferExistsFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class TransferExistsFactory
    {
        public ITransferExists Create(IApplicationDB appDB)
        {
            var _TransferExists = new TransferExists(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTransferExistsExt = timerfactory.Create<ITransferExists>(_TransferExists);

            return iTransferExistsExt;
        }
    }
}
