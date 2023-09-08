//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSUpdateJournalRefFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSUpdateJournalRefFactory
    {
        public ICHSUpdateJournalRef Create(IApplicationDB appDB)
        {
            var _CHSUpdateJournalRef = new CHSUpdateJournalRef(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSUpdateJournalRefExt = timerfactory.Create<ICHSUpdateJournalRef>(_CHSUpdateJournalRef);

            return iCHSUpdateJournalRefExt;
        }
    }
}
