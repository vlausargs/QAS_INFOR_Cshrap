//PROJECT NAME: Reporting
//CLASS NAME: RPT_RSQC_GageReport2SSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RPT_RSQC_GageReport2SSRSFactory
	{
		public IRPT_RSQC_GageReport2SSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RPT_RSQC_GageReport2SSRS = new Reporting.RPT_RSQC_GageReport2SSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRPT_RSQC_GageReport2SSRSExt = timerfactory.Create<Reporting.IRPT_RSQC_GageReport2SSRS>(_RPT_RSQC_GageReport2SSRS);
			
			return iRPT_RSQC_GageReport2SSRSExt;
		}
	}
}
