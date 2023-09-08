//PROJECT NAME: CSICodes
//CLASS NAME: PortalUpdateOrderLineQuantitiesFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class PortalUpdateOrderLineQuantitiesFactory
	{
		public IPortalUpdateOrderLineQuantities Create(IApplicationDB appDB)
		{
			var _PortalUpdateOrderLineQuantities = new Codes.PortalUpdateOrderLineQuantities(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortalUpdateOrderLineQuantitiesExt = timerfactory.Create<Codes.IPortalUpdateOrderLineQuantities>(_PortalUpdateOrderLineQuantities);
			
			return iPortalUpdateOrderLineQuantitiesExt;
		}
	}
}
