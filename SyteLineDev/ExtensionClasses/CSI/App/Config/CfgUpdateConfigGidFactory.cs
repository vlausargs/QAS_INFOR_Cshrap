//PROJECT NAME: Config
//CLASS NAME: CfgUpdateConfigGidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgUpdateConfigGidFactory
	{
		public ICfgUpdateConfigGid Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgUpdateConfigGid = new Config.CfgUpdateConfigGid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgUpdateConfigGidExt = timerfactory.Create<Config.ICfgUpdateConfigGid>(_CfgUpdateConfigGid);
			
			return iCfgUpdateConfigGidExt;
		}
	}
}
