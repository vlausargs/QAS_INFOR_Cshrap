//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtLeavePayExchRateAmtFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArpmtLeavePayExchRateAmtFactory
    {
        public IArpmtLeavePayExchRateAmt Create(IApplicationDB appDB)
        {
            var _ArpmtLeavePayExchRateAmt = new ArpmtLeavePayExchRateAmt(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArpmtLeavePayExchRateAmtExt = timerfactory.Create<IArpmtLeavePayExchRateAmt>(_ArpmtLeavePayExchRateAmt);

            return iArpmtLeavePayExchRateAmtExt;
        }
    }
}
