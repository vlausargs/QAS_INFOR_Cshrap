//PROJECT NAME: Config
//CLASS NAME: CfgIPNCheckFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgIPNCheckFactory
	{
		public ICfgIPNCheck Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgIPNCheck = new Config.CfgIPNCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgIPNCheckExt = timerfactory.Create<Config.ICfgIPNCheck>(_CfgIPNCheck);
			
			return iCfgIPNCheckExt;
		}
	}
}
