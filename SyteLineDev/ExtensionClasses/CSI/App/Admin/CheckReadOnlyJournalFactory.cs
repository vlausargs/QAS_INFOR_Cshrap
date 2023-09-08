//PROJECT NAME: CSIAdmin
//CLASS NAME: CheckReadOnlyJournalFactory.cs

using CSI.MG;

namespace CSI.Admin
{
    public class CheckReadOnlyJournalFactory
    {
        public ICheckReadOnlyJournal Create(IApplicationDB appDB)
        {
            var _CheckReadOnlyJournal = new CheckReadOnlyJournal(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCheckReadOnlyJournalExt = timerfactory.Create<ICheckReadOnlyJournal>(_CheckReadOnlyJournal);

            return iCheckReadOnlyJournalExt;
        }
    }
}
