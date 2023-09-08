//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSJournalSyncFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSJournalSyncFactory
    {
        public ICHSJournalSync Create(IApplicationDB appDB)
        {
            var _CHSJournalSync = new CHSJournalSync(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSJournalSyncExt = timerfactory.Create<ICHSJournalSync>(_CHSJournalSync);

            return iCHSJournalSyncExt;
        }
    }
}