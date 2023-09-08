//PROJECT NAME: Config
//CLASS NAME: SetAvailCfgFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class SetAvailCfgFactory
	{
		public ISetAvailCfg Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _SetAvailCfg = new Config.SetAvailCfg(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetAvailCfgExt = timerfactory.Create<Config.ISetAvailCfg>(_SetAvailCfg);
			
			return iSetAvailCfgExt;
		}
	}
}
