//PROJECT NAME: Config
//CLASS NAME: CfgValidateGIDFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgValidateGIDFactory
	{
		public ICfgValidateGID Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgValidateGID = new Config.CfgValidateGID(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgValidateGIDExt = timerfactory.Create<Config.ICfgValidateGID>(_CfgValidateGID);
			
			return iCfgValidateGIDExt;
		}
	}
}
