//PROJECT NAME: CSIAdmin
//CLASS NAME: Rpt_ConsumerPrivacyFactory.cs

using CSI.MG;

namespace CSI.Reporting.Admin
{
    public class Rpt_ConsumerPrivacyFactory
    {
        public IRpt_ConsumerPrivacy Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _Rpt_ConsumerPrivacy = new Rpt_ConsumerPrivacy(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRpt_ConsumerPrivacyExt = timerfactory.Create<IRpt_ConsumerPrivacy>(_Rpt_ConsumerPrivacy);

            return iRpt_ConsumerPrivacyExt;
        }
    }
}
