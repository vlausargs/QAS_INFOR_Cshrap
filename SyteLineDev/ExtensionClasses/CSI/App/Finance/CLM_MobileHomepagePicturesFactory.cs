//PROJECT NAME: CSIFinance
//CLASS NAME: CLM_MobileHomepagePicturesFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class CLM_MobileHomepagePicturesFactory
    {
        public ICLM_MobileHomepagePictures Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_MobileHomepagePictures = new CLM_MobileHomepagePictures(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLExecutivesExt = timerfactory.Create<ICLM_MobileHomepagePictures>(_CLM_MobileHomepagePictures);

            return iSLExecutivesExt;
        }
    }
}
