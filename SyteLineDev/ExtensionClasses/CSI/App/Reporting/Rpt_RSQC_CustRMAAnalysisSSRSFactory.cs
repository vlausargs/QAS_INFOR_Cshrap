//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_CustRMAAnalysisSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_CustRMAAnalysisSSRSFactory
	{
		public IRpt_RSQC_CustRMAAnalysisSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_CustRMAAnalysisSSRS = new Reporting.Rpt_RSQC_CustRMAAnalysisSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_CustRMAAnalysisSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_CustRMAAnalysisSSRS>(_Rpt_RSQC_CustRMAAnalysisSSRS);
			
			return iRpt_RSQC_CustRMAAnalysisSSRSExt;
		}
	}
}
