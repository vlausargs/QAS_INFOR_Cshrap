//PROJECT NAME: CSIVendor
//CLASS NAME: CLM_GenerateLCVouchersFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_GenerateLCVouchersFactory
	{
		public ICLM_GenerateLCVouchers Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GenerateLCVouchers = new Logistics.Vendor.CLM_GenerateLCVouchers(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GenerateLCVouchersExt = timerfactory.Create<Logistics.Vendor.ICLM_GenerateLCVouchers>(_CLM_GenerateLCVouchers);
			
			return iCLM_GenerateLCVouchersExt;
		}
	}
}
