//PROJECT NAME: Logistics
//CLASS NAME: GetItemPriceAndCostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetItemPriceAndCostFactory
	{
		public IGetItemPriceAndCost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetItemPriceAndCost = new Logistics.Customer.GetItemPriceAndCost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetItemPriceAndCostExt = timerfactory.Create<Logistics.Customer.IGetItemPriceAndCost>(_GetItemPriceAndCost);
			
			return iGetItemPriceAndCostExt;
		}
	}
}
