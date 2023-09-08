//PROJECT NAME: Config
//CLASS NAME: CfgCopyConfigFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgCopyConfigFactory
	{
		public ICfgCopyConfig Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgCopyConfig = new Config.CfgCopyConfig(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgCopyConfigExt = timerfactory.Create<Config.ICfgCopyConfig>(_CfgCopyConfig);
			
			return iCfgCopyConfigExt;
		}
	}
}
