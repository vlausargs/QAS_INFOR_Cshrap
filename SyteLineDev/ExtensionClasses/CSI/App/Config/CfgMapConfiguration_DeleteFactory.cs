//PROJECT NAME: Config
//CLASS NAME: CfgMapConfiguration_DeleteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgMapConfiguration_DeleteFactory
	{
		public ICfgMapConfiguration_Delete Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgMapConfiguration_Delete = new Config.CfgMapConfiguration_Delete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgMapConfiguration_DeleteExt = timerfactory.Create<Config.ICfgMapConfiguration_Delete>(_CfgMapConfiguration_Delete);
			
			return iCfgMapConfiguration_DeleteExt;
		}
	}
}
