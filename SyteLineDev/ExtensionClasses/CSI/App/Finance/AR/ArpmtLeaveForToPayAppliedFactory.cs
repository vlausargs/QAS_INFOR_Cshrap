//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtLeaveForToPayAppliedFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArpmtLeaveForToPayAppliedFactory
    {
        public IArpmtLeaveForToPayApplied Create(IApplicationDB appDB)
        {
            var _ArpmtLeaveForToPayApplied = new ArpmtLeaveForToPayApplied(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArpmtLeaveForToPayAppliedExt = timerfactory.Create<IArpmtLeaveForToPayApplied>(_ArpmtLeaveForToPayApplied);

            return iArpmtLeaveForToPayAppliedExt;
        }
    }
}
