//PROJECT NAME: Reporting
//CLASS NAME: SSSRMXRpt_ReprintVendorPackingListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSRMXRpt_ReprintVendorPackingListFactory
	{
		public ISSSRMXRpt_ReprintVendorPackingList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSRMXRpt_ReprintVendorPackingList = new Reporting.SSSRMXRpt_ReprintVendorPackingList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRMXRpt_ReprintVendorPackingListExt = timerfactory.Create<Reporting.ISSSRMXRpt_ReprintVendorPackingList>(_SSSRMXRpt_ReprintVendorPackingList);
			
			return iSSSRMXRpt_ReprintVendorPackingListExt;
		}
	}
}
