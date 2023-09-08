//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CustomerOpenRecordsReportFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CustomerOpenRecordsReportFactory
	{
		public IRpt_CustomerOpenRecordsReport Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CustomerOpenRecordsReport = new Reporting.Rpt_CustomerOpenRecordsReport(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CustomerOpenRecordsReportExt = timerfactory.Create<Reporting.IRpt_CustomerOpenRecordsReport>(_Rpt_CustomerOpenRecordsReport);
			
			return iRpt_CustomerOpenRecordsReportExt;
		}
	}
}
