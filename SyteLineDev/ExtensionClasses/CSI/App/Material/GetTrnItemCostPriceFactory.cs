//PROJECT NAME: Material
//CLASS NAME: GetTrnItemCostPriceFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class GetTrnItemCostPriceFactory
	{
		public IGetTrnItemCostPrice Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetTrnItemCostPrice = new Material.GetTrnItemCostPrice(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetTrnItemCostPriceExt = timerfactory.Create<Material.IGetTrnItemCostPrice>(_GetTrnItemCostPrice);
			
			return iGetTrnItemCostPriceExt;
		}
	}
}
