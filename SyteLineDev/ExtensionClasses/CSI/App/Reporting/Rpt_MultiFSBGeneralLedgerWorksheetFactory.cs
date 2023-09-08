//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MultiFSBGeneralLedgerWorksheetFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MultiFSBGeneralLedgerWorksheetFactory
	{
		public IRpt_MultiFSBGeneralLedgerWorksheet Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MultiFSBGeneralLedgerWorksheet = new Reporting.Rpt_MultiFSBGeneralLedgerWorksheet(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MultiFSBGeneralLedgerWorksheetExt = timerfactory.Create<Reporting.IRpt_MultiFSBGeneralLedgerWorksheet>(_Rpt_MultiFSBGeneralLedgerWorksheet);
			
			return iRpt_MultiFSBGeneralLedgerWorksheetExt;
		}
	}
}
