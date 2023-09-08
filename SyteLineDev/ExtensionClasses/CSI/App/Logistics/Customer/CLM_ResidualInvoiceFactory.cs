//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_ResidualInvoiceFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CLM_ResidualInvoiceFactory
    {
        public ICLM_ResidualInvoice Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_ResidualInvoice = new CLM_ResidualInvoice(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ResidualInvoiceExt = timerfactory.Create<ICLM_ResidualInvoice>(_CLM_ResidualInvoice);

            return iCLM_ResidualInvoiceExt;
        }
    }
}
