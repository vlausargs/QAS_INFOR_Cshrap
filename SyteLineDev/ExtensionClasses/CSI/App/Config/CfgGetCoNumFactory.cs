//PROJECT NAME: Config
//CLASS NAME: CfgGetCoNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgGetCoNumFactory
	{
		public ICfgGetCoNum Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgGetCoNum = new Config.CfgGetCoNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgGetCoNumExt = timerfactory.Create<Config.ICfgGetCoNum>(_CfgGetCoNum);
			
			return iCfgGetCoNumExt;
		}
	}
}
