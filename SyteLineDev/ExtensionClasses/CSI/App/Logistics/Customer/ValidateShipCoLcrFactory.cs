//PROJECT NAME: Logistics
//CLASS NAME: ValidateShipCoLcrFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateShipCoLcrFactory
	{
		public IValidateShipCoLcr Create(IApplicationDB appDB)
		{
			var _ValidateShipCoLcr = new Logistics.Customer.ValidateShipCoLcr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateShipCoLcrExt = timerfactory.Create<Logistics.Customer.IValidateShipCoLcr>(_ValidateShipCoLcr);
			
			return iValidateShipCoLcrExt;
		}
	}
}
