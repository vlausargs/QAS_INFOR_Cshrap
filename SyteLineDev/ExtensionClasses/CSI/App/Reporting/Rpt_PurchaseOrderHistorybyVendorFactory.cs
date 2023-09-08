//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PurchaseOrderHistorybyVendorFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PurchaseOrderHistorybyVendorFactory
	{
		public IRpt_PurchaseOrderHistorybyVendor Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PurchaseOrderHistorybyVendor = new Reporting.Rpt_PurchaseOrderHistorybyVendor(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PurchaseOrderHistorybyVendorExt = timerfactory.Create<Reporting.IRpt_PurchaseOrderHistorybyVendor>(_Rpt_PurchaseOrderHistorybyVendor);
			
			return iRpt_PurchaseOrderHistorybyVendorExt;
		}
	}
}
