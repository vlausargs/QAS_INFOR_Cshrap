//PROJECT NAME: Config
//CLASS NAME: CfgJobConfigFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgJobConfigFactory
	{
		public ICfgJobConfig Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgJobConfig = new Config.CfgJobConfig(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgJobConfigExt = timerfactory.Create<Config.ICfgJobConfig>(_CfgJobConfig);
			
			return iCfgJobConfigExt;
		}
	}
}
