//PROJECT NAME: CSIAdmin
//CLASS NAME: CLM_GetMobileImageFactory.cs

using CSI.MG;

namespace CSI.Admin
{
    public class CLM_GetMobileImageFactory
    {
        public ICLM_GetMobileImage Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_GetMobileImage = new CLM_GetMobileImage(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_GetMobileImageExt = timerfactory.Create<ICLM_GetMobileImage>(_CLM_GetMobileImage);

            return iCLM_GetMobileImageExt;
        }
    }
}