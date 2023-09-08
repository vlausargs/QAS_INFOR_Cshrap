//PROJECT NAME: Reporting
//CLASS NAME: Rpt_AccountBalancesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_AccountBalancesFactory
	{
		public IRpt_AccountBalances Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_AccountBalances = new Reporting.Rpt_AccountBalances(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_AccountBalancesExt = timerfactory.Create<Reporting.IRpt_AccountBalances>(_Rpt_AccountBalances);
			
			return iRpt_AccountBalancesExt;
		}
	}
}
