//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GeneralLedgerWorksheetFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_GeneralLedgerWorksheetFactory
	{
		public IRpt_GeneralLedgerWorksheet Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_GeneralLedgerWorksheet = new Reporting.Rpt_GeneralLedgerWorksheet(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_GeneralLedgerWorksheetExt = timerfactory.Create<Reporting.IRpt_GeneralLedgerWorksheet>(_Rpt_GeneralLedgerWorksheet);
			
			return iRpt_GeneralLedgerWorksheetExt;
		}
	}
}
