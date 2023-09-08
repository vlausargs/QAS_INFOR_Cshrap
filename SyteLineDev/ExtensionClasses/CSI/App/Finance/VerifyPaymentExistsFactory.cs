//PROJECT NAME: CSIFinance
//CLASS NAME: VerifyPaymentExistsFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class VerifyPaymentExistsFactory
    {
        public IVerifyPaymentExists Create(IApplicationDB appDB)
        {
            var _VerifyPaymentExists = new VerifyPaymentExists(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLBankHdrsExt = timerfactory.Create<IVerifyPaymentExists>(_VerifyPaymentExists);

            return iSLBankHdrsExt;
        }
    }
}
