//PROJECT NAME: Config
//CLASS NAME: GetDocCfgParmsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class GetDocCfgParmsFactory
	{
		public IGetDocCfgParms Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _GetDocCfgParms = new Config.GetDocCfgParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetDocCfgParmsExt = timerfactory.Create<Config.IGetDocCfgParms>(_GetDocCfgParms);
			
			return iGetDocCfgParmsExt;
		}
	}
}
