//PROJECT NAME: Config
//CLASS NAME: CfgConfigurationForBGJobCreationFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgConfigurationForBGJobCreationFactory
	{
		public ICfgConfigurationForBGJobCreation Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgConfigurationForBGJobCreation = new Config.CfgConfigurationForBGJobCreation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgConfigurationForBGJobCreationExt = timerfactory.Create<Config.ICfgConfigurationForBGJobCreation>(_CfgConfigurationForBGJobCreation);
			
			return iCfgConfigurationForBGJobCreationExt;
		}
	}
}
