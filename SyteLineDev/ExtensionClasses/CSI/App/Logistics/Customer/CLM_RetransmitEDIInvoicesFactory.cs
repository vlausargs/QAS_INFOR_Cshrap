//PROJECT NAME: CSICustomer
//CLASS NAME: RetransmitEDIInvoicesFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
    public class CLM_RetransmitEDIInvoicesFactory
    {
        public ICLM_RetransmitEDIInvoices Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _CLM_RetransmitEDIInvoices = new Logistics.Customer.CLM_RetransmitEDIInvoices(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_RetransmitEDIInvoicesExt = timerfactory.Create<Logistics.Customer.ICLM_RetransmitEDIInvoices>(_CLM_RetransmitEDIInvoices);

            return iCLM_RetransmitEDIInvoicesExt;
        }
    }
}
