//PROJECT NAME: Reporting
//CLASS NAME: THARpt_InventoryBalanceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class THARpt_InventoryBalanceFactory
	{
		public ITHARpt_InventoryBalance Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _THARpt_InventoryBalance = new Reporting.THARpt_InventoryBalance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHARpt_InventoryBalanceExt = timerfactory.Create<Reporting.ITHARpt_InventoryBalance>(_THARpt_InventoryBalance);
			
			return iTHARpt_InventoryBalanceExt;
		}
	}
}
