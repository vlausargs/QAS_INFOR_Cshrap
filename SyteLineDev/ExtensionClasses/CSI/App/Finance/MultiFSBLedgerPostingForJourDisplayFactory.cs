//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBLedgerPostingForJourDisplayFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class MultiFSBLedgerPostingForJourDisplayFactory
    {
        public IMultiFSBLedgerPostingForJourDisplay Create(IApplicationDB appDB)
        {
            var _MultiFSBLedgerPostingForJourDisplay = new MultiFSBLedgerPostingForJourDisplay(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFsbJournalsExt = timerfactory.Create<IMultiFSBLedgerPostingForJourDisplay>(_MultiFSBLedgerPostingForJourDisplay);

            return iSLFsbJournalsExt;
        }
    }
}
