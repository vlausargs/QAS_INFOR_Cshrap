//PROJECT NAME: Reporting
//CLASS NAME: RPT_RSQC_GageReportSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RPT_RSQC_GageReportSSRSFactory
	{
		public IRPT_RSQC_GageReportSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RPT_RSQC_GageReportSSRS = new Reporting.RPT_RSQC_GageReportSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRPT_RSQC_GageReportSSRSExt = timerfactory.Create<Reporting.IRPT_RSQC_GageReportSSRS>(_RPT_RSQC_GageReportSSRS);
			
			return iRPT_RSQC_GageReportSSRSExt;
		}
	}
}
