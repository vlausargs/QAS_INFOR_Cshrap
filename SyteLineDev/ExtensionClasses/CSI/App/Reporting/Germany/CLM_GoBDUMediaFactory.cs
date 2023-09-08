//PROJECT NAME: CSIDELOC
//CLASS NAME: CLM_GoBDUMediaFactory.cs

using CSI.MG;

namespace CSI.Reporting.Germany
{
    public class CLM_GoBDUMediaFactory
    {
        public ICLM_GoBDUMedia Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_GoBDUMedia = new CLM_GoBDUMedia(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_GoBDUMediaExt = timerfactory.Create<ICLM_GoBDUMedia>(_CLM_GoBDUMedia);

            return iCLM_GoBDUMediaExt;
        }
    }
}
