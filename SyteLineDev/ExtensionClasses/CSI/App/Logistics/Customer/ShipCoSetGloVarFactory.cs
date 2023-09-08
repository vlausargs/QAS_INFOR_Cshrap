//PROJECT NAME: Logistics
//CLASS NAME: ShipCoSetGloVarFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ShipCoSetGloVarFactory
	{
		public IShipCoSetGloVar Create(IApplicationDB appDB)
		{
			var _ShipCoSetGloVar = new Logistics.Customer.ShipCoSetGloVar(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iShipCoSetGloVarExt = timerfactory.Create<Logistics.Customer.IShipCoSetGloVar>(_ShipCoSetGloVar);
			
			return iShipCoSetGloVarExt;
		}
	}
}
