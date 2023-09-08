//PROJECT NAME: CSIMaterial
//CLASS NAME: IsShipmentShippedFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class IsShipmentShippedFactory
	{
		public IIsShipmentShipped Create(IApplicationDB appDB)
		{
			var _IsShipmentShipped = new Material.IsShipmentShipped(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIsShipmentShippedExt = timerfactory.Create<Material.IIsShipmentShipped>(_IsShipmentShipped);
			
			return iIsShipmentShippedExt;
		}
	}
}
