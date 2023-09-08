//PROJECT NAME: Logistics
//CLASS NAME: ShipCoShipFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ShipCoShipFactory
	{
		public IShipCoShip Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ShipCoShip = new Logistics.Customer.ShipCoShip(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iShipCoShipExt = timerfactory.Create<Logistics.Customer.IShipCoShip>(_ShipCoShip);
			
			return iShipCoShipExt;
		}
	}
}
