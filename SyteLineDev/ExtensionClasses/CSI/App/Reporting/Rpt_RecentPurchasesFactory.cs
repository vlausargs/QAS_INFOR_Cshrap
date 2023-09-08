//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RecentPurchasesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RecentPurchasesFactory
	{
		public IRpt_RecentPurchases Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RecentPurchases = new Reporting.Rpt_RecentPurchases(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RecentPurchasesExt = timerfactory.Create<Reporting.IRpt_RecentPurchases>(_Rpt_RecentPurchases);
			
			return iRpt_RecentPurchasesExt;
		}
	}
}
