//PROJECT NAME: CSICodes
//CLASS NAME: PortalOrderStatusChangeFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class PortalOrderStatusChangeFactory
	{
		public IPortalOrderStatusChange Create(IApplicationDB appDB)
		{
			var _PortalOrderStatusChange = new Codes.PortalOrderStatusChange(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortalOrderStatusChangeExt = timerfactory.Create<Codes.IPortalOrderStatusChange>(_PortalOrderStatusChange);
			
			return iPortalOrderStatusChangeExt;
		}
	}
}
