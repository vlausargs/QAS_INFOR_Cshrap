//PROJECT NAME: CSIAdmin
//CLASS NAME: DelJournalTxFactory.cs

using CSI.MG;

namespace CSI.Admin
{
    public class DelJournalTxFactory
    {
        public IDelJournalTx Create(IApplicationDB appDB)
        {
            var _DelJournalTx = new DelJournalTx(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDelJournalTxExt = timerfactory.Create<IDelJournalTx>(_DelJournalTx);

            return iDelJournalTxExt;
        }
    }
}
