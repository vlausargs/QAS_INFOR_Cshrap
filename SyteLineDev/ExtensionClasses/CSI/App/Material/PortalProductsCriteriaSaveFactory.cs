//PROJECT NAME: CSIMaterial
//CLASS NAME: PortalProductsCriteriaSaveFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class PortalProductsCriteriaSaveFactory
	{
		public IPortalProductsCriteriaSave Create(IApplicationDB appDB)
		{
			var _PortalProductsCriteriaSave = new Material.PortalProductsCriteriaSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortalProductsCriteriaSaveExt = timerfactory.Create<Material.IPortalProductsCriteriaSave>(_PortalProductsCriteriaSave);
			
			return iPortalProductsCriteriaSaveExt;
		}
	}
}
