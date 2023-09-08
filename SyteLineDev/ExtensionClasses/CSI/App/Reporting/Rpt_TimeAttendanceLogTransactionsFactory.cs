//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TimeAttendanceLogTransactionsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_TimeAttendanceLogTransactionsFactory
	{
		public IRpt_TimeAttendanceLogTransactions Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_TimeAttendanceLogTransactions = new Reporting.Rpt_TimeAttendanceLogTransactions(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_TimeAttendanceLogTransactionsExt = timerfactory.Create<Reporting.IRpt_TimeAttendanceLogTransactions>(_Rpt_TimeAttendanceLogTransactions);
			
			return iRpt_TimeAttendanceLogTransactionsExt;
		}
	}
}
