//PROJECT NAME: CSIMaterial
//CLASS NAME: ChangeTransferExchRateFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ChangeTransferExchRateFactory
    {
        public IChangeTransferExchRate Create(IApplicationDB appDB)
        {
            var _ChangeTransferExchRate = new ChangeTransferExchRate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iChangeTransferExchRateExt = timerfactory.Create<IChangeTransferExchRate>(_ChangeTransferExchRate);

            return iChangeTransferExchRateExt;
        }
    }
}
