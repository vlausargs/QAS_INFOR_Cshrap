//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBJournalBalanceFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class MultiFSBJournalBalanceFactory
    {
        public IMultiFSBJournalBalance Create(IApplicationDB appDB)
        {
            var _MultiFSBJournalBalance = new MultiFSBJournalBalance(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFsbJournalsExt = timerfactory.Create<IMultiFSBJournalBalance>(_MultiFSBJournalBalance);

            return iSLFsbJournalsExt;
        }
    }
}
