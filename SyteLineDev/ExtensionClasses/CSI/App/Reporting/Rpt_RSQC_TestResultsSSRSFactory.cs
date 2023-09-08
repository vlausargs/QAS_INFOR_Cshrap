//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_TestResultsSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_TestResultsSSRSFactory
	{
		public IRpt_RSQC_TestResultsSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_TestResultsSSRS = new Reporting.Rpt_RSQC_TestResultsSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_TestResultsSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_TestResultsSSRS>(_Rpt_RSQC_TestResultsSSRS);
			
			return iRpt_RSQC_TestResultsSSRSExt;
		}
	}
}
