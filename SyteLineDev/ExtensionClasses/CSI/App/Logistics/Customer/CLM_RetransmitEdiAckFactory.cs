//PROJECT NAME: CSICustomer
//CLASS NAME: RetransmitEdiAckFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
    public class CLM_RetransmitEdiAckFactory
    {
        public ICLM_RetransmitEdiAck Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _CLM_RetransmitEdiAck = new Logistics.Customer.CLM_RetransmitEdiAck(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_RetransmitEdiAckExt = timerfactory.Create<Logistics.Customer.ICLM_RetransmitEdiAck>(_CLM_RetransmitEdiAck);

            return iCLM_RetransmitEdiAckExt;
        }
    }
}
