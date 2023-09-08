//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FiscalReportingSystemReportFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_FiscalReportingSystemReportFactory
	{
		public IRpt_FiscalReportingSystemReport Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_FiscalReportingSystemReport = new Reporting.Rpt_FiscalReportingSystemReport(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_FiscalReportingSystemReportExt = timerfactory.Create<Reporting.IRpt_FiscalReportingSystemReport>(_Rpt_FiscalReportingSystemReport);
			
			return iRpt_FiscalReportingSystemReportExt;
		}
	}
}
