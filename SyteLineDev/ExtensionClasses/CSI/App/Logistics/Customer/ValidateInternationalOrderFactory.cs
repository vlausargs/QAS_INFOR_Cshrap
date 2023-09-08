//PROJECT NAME: CSICustomer
//CLASS NAME: ValidateInternationalOrderFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateInternationalOrderFactory
	{
		public IValidateInternationalOrder Create(IApplicationDB appDB)
		{
			var _ValidateInternationalOrder = new Logistics.Customer.ValidateInternationalOrder(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateInternationalOrderExt = timerfactory.Create<Logistics.Customer.IValidateInternationalOrder>(_ValidateInternationalOrder);
			
			return iValidateInternationalOrderExt;
		}
	}
}
