//PROJECT NAME: CSICustomer
//CLASS NAME: CreateRmaRequestFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CreateRmaRequestFactory
	{
		public ICreateRmaRequest Create(IApplicationDB appDB)
		{
			var _CreateRmaRequest = new Logistics.Customer.CreateRmaRequest(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreateRmaRequestExt = timerfactory.Create<Logistics.Customer.ICreateRmaRequest>(_CreateRmaRequest);
			
			return iCreateRmaRequestExt;
		}
	}
}
