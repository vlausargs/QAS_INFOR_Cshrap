//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PrintInventorySheetsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PrintInventorySheetsFactory
	{
		public IRpt_PrintInventorySheets Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PrintInventorySheets = new Reporting.Rpt_PrintInventorySheets(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PrintInventorySheetsExt = timerfactory.Create<Reporting.IRpt_PrintInventorySheets>(_Rpt_PrintInventorySheets);
			
			return iRpt_PrintInventorySheetsExt;
		}
	}
}
