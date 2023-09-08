//PROJECT NAME: Reporting
//CLASS NAME: SSSRMXRpt_VendorToBeShippedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSRMXRpt_VendorToBeShippedFactory
	{
		public ISSSRMXRpt_VendorToBeShipped Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSRMXRpt_VendorToBeShipped = new Reporting.SSSRMXRpt_VendorToBeShipped(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRMXRpt_VendorToBeShippedExt = timerfactory.Create<Reporting.ISSSRMXRpt_VendorToBeShipped>(_SSSRMXRpt_VendorToBeShipped);
			
			return iSSSRMXRpt_VendorToBeShippedExt;
		}
	}
}
