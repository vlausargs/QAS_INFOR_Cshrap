//PROJECT NAME: Config
//CLASS NAME: CfgGetOrigSiteViaTransferFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Config
{
	public class CfgGetOrigSiteViaTransferFactory
	{
		public ICfgGetOrigSiteViaTransfer Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CfgGetOrigSiteViaTransfer = new Config.CfgGetOrigSiteViaTransfer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgGetOrigSiteViaTransferExt = timerfactory.Create<Config.ICfgGetOrigSiteViaTransfer>(_CfgGetOrigSiteViaTransfer);
			
			return iCfgGetOrigSiteViaTransferExt;
		}
	}
}
