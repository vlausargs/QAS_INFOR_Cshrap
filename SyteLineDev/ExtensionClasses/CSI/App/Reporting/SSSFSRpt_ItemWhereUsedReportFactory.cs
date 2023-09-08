//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_ItemWhereUsedReportFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_ItemWhereUsedReportFactory
	{
		public ISSSFSRpt_ItemWhereUsedReport Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_ItemWhereUsedReport = new Reporting.SSSFSRpt_ItemWhereUsedReport(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_ItemWhereUsedReportExt = timerfactory.Create<Reporting.ISSSFSRpt_ItemWhereUsedReport>(_SSSFSRpt_ItemWhereUsedReport);
			
			return iSSSFSRpt_ItemWhereUsedReportExt;
		}
	}
}
