//PROJECT NAME: Logistics
//CLASS NAME: ValidateShipCoAFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateShipCoAFactory
	{
		public IValidateShipCoA Create(IApplicationDB appDB)
		{
			var _ValidateShipCoA = new Logistics.Customer.ValidateShipCoA(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateShipCoAExt = timerfactory.Create<Logistics.Customer.IValidateShipCoA>(_ValidateShipCoA);
			
			return iValidateShipCoAExt;
		}
	}
}
