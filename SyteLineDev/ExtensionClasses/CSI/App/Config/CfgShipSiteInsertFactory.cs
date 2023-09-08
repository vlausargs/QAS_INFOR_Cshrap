//PROJECT NAME: Config
//CLASS NAME: CfgShipSiteInsertFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgShipSiteInsertFactory
	{
		public ICfgShipSiteInsert Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgShipSiteInsert = new Config.CfgShipSiteInsert(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgShipSiteInsertExt = timerfactory.Create<Config.ICfgShipSiteInsert>(_CfgShipSiteInsert);
			
			return iCfgShipSiteInsertExt;
		}
	}
}
