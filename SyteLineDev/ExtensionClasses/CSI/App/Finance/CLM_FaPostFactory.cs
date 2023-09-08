//PROJECT NAME: CSIFinance
//CLASS NAME: CLM_FaPostFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class CLM_FaPostFactory
    {
        public ICLM_FaPost Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_FaPost = new CLM_FaPost(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFaDistsExt = timerfactory.Create<ICLM_FaPost>(_CLM_FaPost);

            return iSLFaDistsExt;
        }
    }
}
