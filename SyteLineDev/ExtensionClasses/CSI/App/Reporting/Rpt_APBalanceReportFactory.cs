//PROJECT NAME: Reporting
//CLASS NAME: Rpt_APBalanceReportFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_APBalanceReportFactory
	{
		public IRpt_APBalanceReport Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_APBalanceReport = new Reporting.Rpt_APBalanceReport(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_APBalanceReportExt = timerfactory.Create<Reporting.IRpt_APBalanceReport>(_Rpt_APBalanceReport);
			
			return iRpt_APBalanceReportExt;
		}
	}
}
