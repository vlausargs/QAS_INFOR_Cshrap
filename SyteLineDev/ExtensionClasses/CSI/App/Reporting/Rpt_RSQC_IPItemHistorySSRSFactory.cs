//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_IPItemHistorySSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_IPItemHistorySSRSFactory
	{
		public IRpt_RSQC_IPItemHistorySSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_IPItemHistorySSRS = new Reporting.Rpt_RSQC_IPItemHistorySSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_IPItemHistorySSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_IPItemHistorySSRS>(_Rpt_RSQC_IPItemHistorySSRS);
			
			return iRpt_RSQC_IPItemHistorySSRSExt;
		}
	}
}
