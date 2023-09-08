//PROJECT NAME: CSIFinance
//CLASS NAME: JournalBuilderValidateAcctFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class JournalBuilderValidateAcctFactory
    {
        public IJournalBuilderValidateAcct Create(IApplicationDB appDB)
        {
            var _JournalBuilderValidateAcct = new JournalBuilderValidateAcct(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLJournalsExt = timerfactory.Create<IJournalBuilderValidateAcct>(_JournalBuilderValidateAcct);

            return iSLJournalsExt;
        }
    }
}
