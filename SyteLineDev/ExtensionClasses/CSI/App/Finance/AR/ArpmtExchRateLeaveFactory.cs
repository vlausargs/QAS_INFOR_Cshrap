//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtExchRateLeaveFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArpmtExchRateLeaveFactory
    {
        public IArpmtExchRateLeave Create(IApplicationDB appDB)
        {
            var _ArpmtExchRateLeave = new ArpmtExchRateLeave(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArpmtExchRateLeaveExt = timerfactory.Create<IArpmtExchRateLeave>(_ArpmtExchRateLeave);

            return iArpmtExchRateLeaveExt;
        }
    }
}
