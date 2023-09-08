//PROJECT NAME: Material
//CLASS NAME: GetUnitPricingFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class GetUnitPricingFactory
	{
		public IGetUnitPricing Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _GetUnitPricing = new Material.GetUnitPricing(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetUnitPricingExt = timerfactory.Create<Material.IGetUnitPricing>(_GetUnitPricing);
			
			return iGetUnitPricingExt;
		}
	}
}
