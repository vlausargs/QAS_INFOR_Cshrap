//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_SupItemHistorySSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_SupItemHistorySSRSFactory
	{
		public IRpt_RSQC_SupItemHistorySSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_SupItemHistorySSRS = new Reporting.Rpt_RSQC_SupItemHistorySSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_SupItemHistorySSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_SupItemHistorySSRS>(_Rpt_RSQC_SupItemHistorySSRS);
			
			return iRpt_RSQC_SupItemHistorySSRSExt;
		}
	}
}
