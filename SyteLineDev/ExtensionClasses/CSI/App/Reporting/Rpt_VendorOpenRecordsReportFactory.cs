//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VendorOpenRecordsReportFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_VendorOpenRecordsReportFactory
	{
		public IRpt_VendorOpenRecordsReport Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_VendorOpenRecordsReport = new Reporting.Rpt_VendorOpenRecordsReport(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_VendorOpenRecordsReportExt = timerfactory.Create<Reporting.IRpt_VendorOpenRecordsReport>(_Rpt_VendorOpenRecordsReport);
			
			return iRpt_VendorOpenRecordsReportExt;
		}
	}
}
