//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_DeleteARPostedTransFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CLM_DeleteARPostedTransFactory
    {
        public ICLM_DeleteARPostedTrans Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_DeleteARPostedTrans = new CLM_DeleteARPostedTrans(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_DeleteARPostedTransExt = timerfactory.Create<ICLM_DeleteARPostedTrans>(_CLM_DeleteARPostedTrans);

            return iCLM_DeleteARPostedTransExt;
        }
    }
}
