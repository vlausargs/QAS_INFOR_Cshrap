//PROJECT NAME: Codes
//CLASS NAME: GetPortalAlertParmsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class GetPortalAlertParmsFactory
	{
		public IGetPortalAlertParms Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _GetPortalAlertParms = new Codes.GetPortalAlertParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetPortalAlertParmsExt = timerfactory.Create<Codes.IGetPortalAlertParms>(_GetPortalAlertParms);
			
			return iGetPortalAlertParmsExt;
		}
	}
}
