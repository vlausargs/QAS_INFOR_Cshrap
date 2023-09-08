//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VerifyReportstoAccountsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_VerifyReportstoAccountsFactory
	{
		public IRpt_VerifyReportstoAccounts Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_VerifyReportstoAccounts = new Reporting.Rpt_VerifyReportstoAccounts(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_VerifyReportstoAccountsExt = timerfactory.Create<Reporting.IRpt_VerifyReportstoAccounts>(_Rpt_VerifyReportstoAccounts);
			
			return iRpt_VerifyReportstoAccountsExt;
		}
	}
}
