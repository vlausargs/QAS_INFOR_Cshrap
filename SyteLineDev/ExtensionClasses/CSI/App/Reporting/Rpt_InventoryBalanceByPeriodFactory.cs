//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InventoryBalanceByPeriodFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_InventoryBalanceByPeriodFactory
	{
		public IRpt_InventoryBalanceByPeriod Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InventoryBalanceByPeriod = new Reporting.Rpt_InventoryBalanceByPeriod(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InventoryBalanceByPeriodExt = timerfactory.Create<Reporting.IRpt_InventoryBalanceByPeriod>(_Rpt_InventoryBalanceByPeriod);
			
			return iRpt_InventoryBalanceByPeriodExt;
		}
	}
}
