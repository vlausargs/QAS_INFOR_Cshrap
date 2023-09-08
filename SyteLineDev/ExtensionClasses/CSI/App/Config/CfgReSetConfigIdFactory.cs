//PROJECT NAME: Config
//CLASS NAME: CfgReSetConfigIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgReSetConfigIdFactory
	{
		public ICfgReSetConfigId Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgReSetConfigId = new Config.CfgReSetConfigId(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgReSetConfigIdExt = timerfactory.Create<Config.ICfgReSetConfigId>(_CfgReSetConfigId);
			
			return iCfgReSetConfigIdExt;
		}
	}
}
