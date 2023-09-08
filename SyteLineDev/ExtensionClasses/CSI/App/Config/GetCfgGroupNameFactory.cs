//PROJECT NAME: Config
//CLASS NAME: GetCfgGroupNameFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class GetCfgGroupNameFactory
	{
		public IGetCfgGroupName Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _GetCfgGroupName = new Config.GetCfgGroupName(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCfgGroupNameExt = timerfactory.Create<Config.IGetCfgGroupName>(_GetCfgGroupName);
			
			return iGetCfgGroupNameExt;
		}
	}
}
