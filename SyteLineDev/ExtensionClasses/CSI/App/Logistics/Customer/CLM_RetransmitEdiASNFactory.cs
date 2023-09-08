//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_RetransmitEdiASNFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
    public class CLM_RetransmitEdiASNFactory
    {
        public ICLM_RetransmitEdiASN Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _CLM_RetransmitEdiASN = new Logistics.Customer.CLM_RetransmitEdiASN(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_RetransmitEdiASNExt = timerfactory.Create<Logistics.Customer.ICLM_RetransmitEdiASN>(_CLM_RetransmitEdiASN);

            return iCLM_RetransmitEdiASNExt;
        }
    }
}
