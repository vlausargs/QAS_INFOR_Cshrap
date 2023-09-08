//PROJECT NAME: Config
//CLASS NAME: CfgDoConfigFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgDoConfigFactory
	{
		public ICfgDoConfig Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgDoConfig = new Config.CfgDoConfig(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgDoConfigExt = timerfactory.Create<Config.ICfgDoConfig>(_CfgDoConfig);
			
			return iCfgDoConfigExt;
		}
	}
}
