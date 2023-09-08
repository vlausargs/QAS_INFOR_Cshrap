//PROJECT NAME: Config
//CLASS NAME: CfgGetStatFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgGetStatFactory
	{
		public ICfgGetStat Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgGetStat = new Config.CfgGetStat(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgGetStatExt = timerfactory.Create<Config.ICfgGetStat>(_CfgGetStat);
			
			return iCfgGetStatExt;
		}
	}
}
