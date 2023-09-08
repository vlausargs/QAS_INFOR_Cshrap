//PROJECT NAME: Config
//CLASS NAME: CfgCheckRefsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgCheckRefsFactory
	{
		public ICfgCheckRefs Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgCheckRefs = new Config.CfgCheckRefs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgCheckRefsExt = timerfactory.Create<Config.ICfgCheckRefs>(_CfgCheckRefs);
			
			return iCfgCheckRefsExt;
		}
	}
}
