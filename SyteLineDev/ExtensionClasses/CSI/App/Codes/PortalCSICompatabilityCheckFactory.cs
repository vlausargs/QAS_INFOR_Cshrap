//PROJECT NAME: Codes
//CLASS NAME: PortalCSICompatabilityCheckFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class PortalCSICompatabilityCheckFactory
	{
		public IPortalCSICompatabilityCheck Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _PortalCSICompatabilityCheck = new Codes.PortalCSICompatabilityCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortalCSICompatabilityCheckExt = timerfactory.Create<Codes.IPortalCSICompatabilityCheck>(_PortalCSICompatabilityCheck);
			
			return iPortalCSICompatabilityCheckExt;
		}
	}
}
