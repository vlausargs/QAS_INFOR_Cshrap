//PROJECT NAME: CSIMaterial
//CLASS NAME: TransferDefaultsFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class TransferDefaultsFactory
    {
        public ITransferDefaults Create(IApplicationDB appDB)
        {
            var _TransferDefaults = new TransferDefaults(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTransferDefaultsExt = timerfactory.Create<ITransferDefaults>(_TransferDefaults);

            return iTransferDefaultsExt;
        }
    }
}
