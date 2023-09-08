//PROJECT NAME: THLOC
//CLASS NAME: THACreateStockBalanceConsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.THLOC
{
	public class THACreateStockBalanceConsFactory
	{
		public ITHACreateStockBalanceCons Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _THACreateStockBalanceCons = new THLOC.THACreateStockBalanceCons(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHACreateStockBalanceConsExt = timerfactory.Create<THLOC.ITHACreateStockBalanceCons>(_THACreateStockBalanceCons);
			
			return iTHACreateStockBalanceConsExt;
		}
	}
}
