//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARBalanceReportFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ARBalanceReportFactory
	{
		public IRpt_ARBalanceReport Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ARBalanceReport = new Reporting.Rpt_ARBalanceReport(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ARBalanceReportExt = timerfactory.Create<Reporting.IRpt_ARBalanceReport>(_Rpt_ARBalanceReport);
			
			return iRpt_ARBalanceReportExt;
		}
	}
}
