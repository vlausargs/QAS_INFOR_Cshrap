//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_CustomerAgingBucketsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_CustomerAgingBucketsFactory
	{
		public ICLM_CustomerAgingBuckets Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_CustomerAgingBuckets = new Logistics.Customer.CLM_CustomerAgingBuckets(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_CustomerAgingBucketsExt = timerfactory.Create<Logistics.Customer.ICLM_CustomerAgingBuckets>(_CLM_CustomerAgingBuckets);
			
			return iCLM_CustomerAgingBucketsExt;
		}
	}
}
