//PROJECT NAME: Config
//CLASS NAME: CfgGetFieldsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgGetFieldsFactory
	{
		public ICfgGetFields Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgGetFields = new Config.CfgGetFields(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgGetFieldsExt = timerfactory.Create<Config.ICfgGetFields>(_CfgGetFields);
			
			return iCfgGetFieldsExt;
		}
	}
}
