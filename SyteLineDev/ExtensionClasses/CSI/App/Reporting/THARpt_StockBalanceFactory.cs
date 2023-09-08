//PROJECT NAME: Reporting
//CLASS NAME: THARpt_StockBalanceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class THARpt_StockBalanceFactory
	{
		public ITHARpt_StockBalance Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _THARpt_StockBalance = new Reporting.THARpt_StockBalance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHARpt_StockBalanceExt = timerfactory.Create<Reporting.ITHARpt_StockBalance>(_THARpt_StockBalance);
			
			return iTHARpt_StockBalanceExt;
		}
	}
}
