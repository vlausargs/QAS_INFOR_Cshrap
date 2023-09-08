//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PrintingEstimateWorksheetFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PrintingEstimateWorksheetFactory
	{
		public IRpt_PrintingEstimateWorksheet Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PrintingEstimateWorksheet = new Reporting.Rpt_PrintingEstimateWorksheet(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PrintingEstimateWorksheetExt = timerfactory.Create<Reporting.IRpt_PrintingEstimateWorksheet>(_Rpt_PrintingEstimateWorksheet);
			
			return iRpt_PrintingEstimateWorksheetExt;
		}
	}
}
