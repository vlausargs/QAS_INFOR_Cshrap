//PROJECT NAME: CSICustomer
//CLASS NAME: SubmitOrderConfirmationFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SubmitOrderConfirmationFactory
	{
		public ISubmitOrderConfirmation Create(IApplicationDB appDB)
		{
			var _SubmitOrderConfirmation = new Logistics.Customer.SubmitOrderConfirmation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSubmitOrderConfirmationExt = timerfactory.Create<Logistics.Customer.ISubmitOrderConfirmation>(_SubmitOrderConfirmation);
			
			return iSubmitOrderConfirmationExt;
		}
	}
}
