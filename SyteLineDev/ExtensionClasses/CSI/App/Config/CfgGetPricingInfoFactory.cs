//PROJECT NAME: Config
//CLASS NAME: CfgGetPricingInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgGetPricingInfoFactory
	{
		public ICfgGetPricingInfo Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgGetPricingInfo = new Config.CfgGetPricingInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgGetPricingInfoExt = timerfactory.Create<Config.ICfgGetPricingInfo>(_CfgGetPricingInfo);
			
			return iCfgGetPricingInfoExt;
		}
	}
}
