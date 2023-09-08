//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_IPResultsWorksheetSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_IPResultsWorksheetSSRSFactory
	{
		public IRpt_RSQC_IPResultsWorksheetSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_IPResultsWorksheetSSRS = new Reporting.Rpt_RSQC_IPResultsWorksheetSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_IPResultsWorksheetSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_IPResultsWorksheetSSRS>(_Rpt_RSQC_IPResultsWorksheetSSRS);
			
			return iRpt_RSQC_IPResultsWorksheetSSRSExt;
		}
	}
}
