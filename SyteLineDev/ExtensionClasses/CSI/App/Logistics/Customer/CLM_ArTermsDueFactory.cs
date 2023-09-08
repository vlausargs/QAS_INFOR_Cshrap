//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_ArTermsDueFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CLM_ArTermsDueFactory
    {
        public ICLM_ArTermsDue Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_ArTermsDue = new CLM_ArTermsDue(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ArTermsDueExt = timerfactory.Create<ICLM_ArTermsDue>(_CLM_ArTermsDue);

            return iCLM_ArTermsDueExt;
        }
    }
}
