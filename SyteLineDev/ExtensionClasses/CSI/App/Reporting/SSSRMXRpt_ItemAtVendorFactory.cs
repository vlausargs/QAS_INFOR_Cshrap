//PROJECT NAME: Reporting
//CLASS NAME: SSSRMXRpt_ItemAtVendorFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSRMXRpt_ItemAtVendorFactory
	{
		public ISSSRMXRpt_ItemAtVendor Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSRMXRpt_ItemAtVendor = new Reporting.SSSRMXRpt_ItemAtVendor(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRMXRpt_ItemAtVendorExt = timerfactory.Create<Reporting.ISSSRMXRpt_ItemAtVendor>(_SSSRMXRpt_ItemAtVendor);
			
			return iSSSRMXRpt_ItemAtVendorExt;
		}
	}
}
