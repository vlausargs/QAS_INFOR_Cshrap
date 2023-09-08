//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_SupVendorPerformanceSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_SupVendorPerformanceSSRSFactory
	{
		public IRpt_RSQC_SupVendorPerformanceSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_SupVendorPerformanceSSRS = new Reporting.Rpt_RSQC_SupVendorPerformanceSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_SupVendorPerformanceSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_SupVendorPerformanceSSRS>(_Rpt_RSQC_SupVendorPerformanceSSRS);
			
			return iRpt_RSQC_SupVendorPerformanceSSRSExt;
		}
	}
}
