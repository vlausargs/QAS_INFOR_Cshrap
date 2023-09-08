//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GeneralLedgerTransactionS01DNReportFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_GeneralLedgerTransactionS01DNReportFactory
	{
		public IRpt_GeneralLedgerTransactionS01DNReport Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_GeneralLedgerTransactionS01DNReport = new Reporting.Rpt_GeneralLedgerTransactionS01DNReport(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_GeneralLedgerTransactionS01DNReportExt = timerfactory.Create<Reporting.IRpt_GeneralLedgerTransactionS01DNReport>(_Rpt_GeneralLedgerTransactionS01DNReport);
			
			return iRpt_GeneralLedgerTransactionS01DNReportExt;
		}
	}
}
