//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtLeavePayToCustAmtFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArpmtLeavePayToCustAmtFactory
    {
        public IArpmtLeavePayToCustAmt Create(IApplicationDB appDB)
        {
            var _ArpmtLeavePayToCustAmt = new ArpmtLeavePayToCustAmt(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArpmtLeavePayToCustAmtExt = timerfactory.Create<IArpmtLeavePayToCustAmt>(_ArpmtLeavePayToCustAmt);

            return iArpmtLeavePayToCustAmtExt;
        }
    }
}
