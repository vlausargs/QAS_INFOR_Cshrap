//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_MobileControllerFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CLM_MobileControllerFactory
    {
        public ICLM_MobileController Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_MobileController = new Customer.CLM_MobileController(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_MobileControllerExt = timerfactory.Create<Customer.ICLM_MobileController>(_CLM_MobileController);

            return iCLM_MobileControllerExt;
        }
    }
}
