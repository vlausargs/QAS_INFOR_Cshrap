//PROJECT NAME: CSIVendor
//CLASS NAME: CLM_AppmtChecksToPrintPostFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_AppmtChecksToPrintPostFactory
	{
		public ICLM_AppmtChecksToPrintPost Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_AppmtChecksToPrintPost = new Logistics.Vendor.CLM_AppmtChecksToPrintPost(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_AppmtChecksToPrintPostExt = timerfactory.Create<Logistics.Vendor.ICLM_AppmtChecksToPrintPost>(_CLM_AppmtChecksToPrintPost);
			
			return iCLM_AppmtChecksToPrintPostExt;
		}
	}
}
