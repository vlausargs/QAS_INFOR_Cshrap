//PROJECT NAME: CSICustomer
//CLASS NAME: ArBalanceHistoryFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArBalanceHistoryFactory
    {
        public IArBalanceHistory Create(IApplicationDB appDB)
        {
            var _ArBalanceHistory = new ArBalanceHistory(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArBalanceHistoryExt = timerfactory.Create<IArBalanceHistory>(_ArBalanceHistory);

            return iArBalanceHistoryExt;
        }
    }
}
