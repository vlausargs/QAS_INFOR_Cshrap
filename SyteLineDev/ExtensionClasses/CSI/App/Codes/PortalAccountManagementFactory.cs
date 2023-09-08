//PROJECT NAME: Codes
//CLASS NAME: PortalAccountManagementFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class PortalAccountManagementFactory
	{
		public IPortalAccountManagement Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PortalAccountManagement = new Codes.PortalAccountManagement(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortalAccountManagementExt = timerfactory.Create<Codes.IPortalAccountManagement>(_PortalAccountManagement);
			
			return iPortalAccountManagementExt;
		}
	}
}
