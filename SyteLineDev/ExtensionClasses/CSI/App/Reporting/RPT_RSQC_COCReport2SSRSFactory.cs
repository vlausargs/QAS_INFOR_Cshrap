//PROJECT NAME: Reporting
//CLASS NAME: RPT_RSQC_COCReport2SSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RPT_RSQC_COCReport2SSRSFactory
	{
		public IRPT_RSQC_COCReport2SSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RPT_RSQC_COCReport2SSRS = new Reporting.RPT_RSQC_COCReport2SSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRPT_RSQC_COCReport2SSRSExt = timerfactory.Create<Reporting.IRPT_RSQC_COCReport2SSRS>(_RPT_RSQC_COCReport2SSRS);
			
			return iRPT_RSQC_COCReport2SSRSExt;
		}
	}
}
