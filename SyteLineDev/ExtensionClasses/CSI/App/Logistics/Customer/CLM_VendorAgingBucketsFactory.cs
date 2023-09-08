//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_VendorAgingBucketsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_VendorAgingBucketsFactory
	{
		public ICLM_VendorAgingBuckets Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_VendorAgingBuckets = new Logistics.Customer.CLM_VendorAgingBuckets(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_VendorAgingBucketsExt = timerfactory.Create<Logistics.Customer.ICLM_VendorAgingBuckets>(_CLM_VendorAgingBuckets);
			
			return iCLM_VendorAgingBucketsExt;
		}
	}
}
