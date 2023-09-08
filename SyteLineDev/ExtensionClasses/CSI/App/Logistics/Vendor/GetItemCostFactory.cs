//PROJECT NAME: Logistics
//CLASS NAME: GetItemCostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetItemCostFactory
	{
		public IGetItemCost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetItemCost = new Logistics.Vendor.GetItemCost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetItemCostExt = timerfactory.Create<Logistics.Vendor.IGetItemCost>(_GetItemCost);
			
			return iGetItemCostExt;
		}
	}
}
