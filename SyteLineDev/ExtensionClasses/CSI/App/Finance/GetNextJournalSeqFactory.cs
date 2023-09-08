//PROJECT NAME: CSIFinance
//CLASS NAME: GetNextJournalSeqFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class GetNextJournalSeqFactory
    {
        public IGetNextJournalSeq Create(IApplicationDB appDB)
        {
            var _GetNextJournalSeq = new GetNextJournalSeq(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLJournalsExt = timerfactory.Create<IGetNextJournalSeq>(_GetNextJournalSeq);

            return iSLJournalsExt;
        }
    }
}
