//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_SupReadyForInspSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_SupReadyForInspSSRSFactory
	{
		public IRpt_RSQC_SupReadyForInspSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_SupReadyForInspSSRS = new Reporting.Rpt_RSQC_SupReadyForInspSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_SupReadyForInspSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_SupReadyForInspSSRS>(_Rpt_RSQC_SupReadyForInspSSRS);
			
			return iRpt_RSQC_SupReadyForInspSSRSExt;
		}
	}
}
