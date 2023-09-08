//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MultiFSBAccountBalancesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MultiFSBAccountBalancesFactory
	{
		public IRpt_MultiFSBAccountBalances Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MultiFSBAccountBalances = new Reporting.Rpt_MultiFSBAccountBalances(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MultiFSBAccountBalancesExt = timerfactory.Create<Reporting.IRpt_MultiFSBAccountBalances>(_Rpt_MultiFSBAccountBalances);
			
			return iRpt_MultiFSBAccountBalancesExt;
		}
	}
}
