//PROJECT NAME: Config
//CLASS NAME: CfgGetOrigSiteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgGetOrigSiteFactory
	{
		public ICfgGetOrigSite Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgGetOrigSite = new Config.CfgGetOrigSite(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgGetOrigSiteExt = timerfactory.Create<Config.ICfgGetOrigSite>(_CfgGetOrigSite);
			
			return iCfgGetOrigSiteExt;
		}
	}
}
