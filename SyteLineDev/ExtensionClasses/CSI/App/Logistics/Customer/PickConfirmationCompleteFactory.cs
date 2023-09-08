//PROJECT NAME: CSICustomer
//CLASS NAME: PickConfirmationCompleteFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PickConfirmationCompleteFactory
	{
		public IPickConfirmationComplete Create(IApplicationDB appDB)
		{
			var _PickConfirmationComplete = new Logistics.Customer.PickConfirmationComplete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPickConfirmationCompleteExt = timerfactory.Create<Logistics.Customer.IPickConfirmationComplete>(_PickConfirmationComplete);
			
			return iPickConfirmationCompleteExt;
		}
	}
}
