//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSPaymentAmtValidFactory.cs

using CSI.MG;

namespace CSI.POS
{
    public class SSSPOSPaymentAmtValidFactory
    {
        public ISSSPOSPaymentAmtValid Create(IApplicationDB appDB)
        {
            var _SSSPOSPaymentAmtValid = new POS.SSSPOSPaymentAmtValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSPOSPaymentAmtValidExt = timerfactory.Create<POS.ISSSPOSPaymentAmtValid>(_SSSPOSPaymentAmtValid);

            return iSSSPOSPaymentAmtValidExt;
        }
    }
}
