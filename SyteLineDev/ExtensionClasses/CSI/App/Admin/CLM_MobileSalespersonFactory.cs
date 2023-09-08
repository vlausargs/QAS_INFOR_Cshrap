//PROJECT NAME: CSIAdmin
//CLASS NAME: CLM_MobileSalespersonFactory.cs

using CSI.MG;

namespace CSI.Admin
{
    public class CLM_MobileSalespersonFactory
    {
        public ICLM_MobileSalesperson Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_MobileSalesperson = new CLM_MobileSalesperson(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_MobileSalespersonExt = timerfactory.Create<ICLM_MobileSalesperson>(_CLM_MobileSalesperson);

            return iCLM_MobileSalespersonExt;
        }
    }
}
