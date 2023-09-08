//PROJECT NAME: CSICustomer
//CLASS NAME: PickConfirmationFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PickConfirmationFactory
	{
		public IPickConfirmation Create(IApplicationDB appDB)
		{
			var _PickConfirmation = new Logistics.Customer.PickConfirmation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPickConfirmationExt = timerfactory.Create<Logistics.Customer.IPickConfirmation>(_PickConfirmation);
			
			return iPickConfirmationExt;
		}
	}
}
