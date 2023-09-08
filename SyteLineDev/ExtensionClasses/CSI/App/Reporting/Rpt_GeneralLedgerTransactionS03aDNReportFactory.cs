//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GeneralLedgerTransactionS03aDNReportFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_GeneralLedgerTransactionS03aDNReportFactory
	{
		public IRpt_GeneralLedgerTransactionS03aDNReport Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_GeneralLedgerTransactionS03aDNReport = new Reporting.Rpt_GeneralLedgerTransactionS03aDNReport(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_GeneralLedgerTransactionS03aDNReportExt = timerfactory.Create<Reporting.IRpt_GeneralLedgerTransactionS03aDNReport>(_Rpt_GeneralLedgerTransactionS03aDNReport);
			
			return iRpt_GeneralLedgerTransactionS03aDNReportExt;
		}
	}
}
