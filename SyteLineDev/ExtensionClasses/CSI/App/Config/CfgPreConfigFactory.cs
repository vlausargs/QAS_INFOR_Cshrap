//PROJECT NAME: Config
//CLASS NAME: CfgPreConfigFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgPreConfigFactory
	{
		public ICfgPreConfig Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgPreConfig = new Config.CfgPreConfig(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgPreConfigExt = timerfactory.Create<Config.ICfgPreConfig>(_CfgPreConfig);
			
			return iCfgPreConfigExt;
		}
	}
}
