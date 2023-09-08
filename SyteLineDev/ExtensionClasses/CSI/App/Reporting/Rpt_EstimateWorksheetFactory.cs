//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EstimateWorksheetFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_EstimateWorksheetFactory
	{
		public IRpt_EstimateWorksheet Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_EstimateWorksheet = new Reporting.Rpt_EstimateWorksheet(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_EstimateWorksheetExt = timerfactory.Create<Reporting.IRpt_EstimateWorksheet>(_Rpt_EstimateWorksheet);
			
			return iRpt_EstimateWorksheetExt;
		}
	}
}
