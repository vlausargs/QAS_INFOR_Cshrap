//PROJECT NAME: Production
//CLASS NAME: RSQC_CLM_SupVendorPerformanceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Quality
{
	public class RSQC_CLM_SupVendorPerformanceFactory
	{
		public IRSQC_CLM_SupVendorPerformance Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RSQC_CLM_SupVendorPerformance = new Production.Quality.RSQC_CLM_SupVendorPerformance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CLM_SupVendorPerformanceExt = timerfactory.Create<Production.Quality.IRSQC_CLM_SupVendorPerformance>(_RSQC_CLM_SupVendorPerformance);
			
			return iRSQC_CLM_SupVendorPerformanceExt;
		}
	}
}
