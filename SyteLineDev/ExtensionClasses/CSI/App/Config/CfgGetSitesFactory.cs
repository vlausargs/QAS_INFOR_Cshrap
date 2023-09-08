//PROJECT NAME: Config
//CLASS NAME: CfgGetSitesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgGetSitesFactory
	{
		public ICfgGetSites Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgGetSites = new Config.CfgGetSites(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgGetSitesExt = timerfactory.Create<Config.ICfgGetSites>(_CfgGetSites);
			
			return iCfgGetSitesExt;
		}
	}
}
