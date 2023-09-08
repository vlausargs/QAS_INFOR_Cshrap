//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MultiFSBGeneralLedgerbyAccountFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MultiFSBGeneralLedgerbyAccountFactory
	{
		public IRpt_MultiFSBGeneralLedgerbyAccount Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MultiFSBGeneralLedgerbyAccount = new Reporting.Rpt_MultiFSBGeneralLedgerbyAccount(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MultiFSBGeneralLedgerbyAccountExt = timerfactory.Create<Reporting.IRpt_MultiFSBGeneralLedgerbyAccount>(_Rpt_MultiFSBGeneralLedgerbyAccount);
			
			return iRpt_MultiFSBGeneralLedgerbyAccountExt;
		}
	}
}
