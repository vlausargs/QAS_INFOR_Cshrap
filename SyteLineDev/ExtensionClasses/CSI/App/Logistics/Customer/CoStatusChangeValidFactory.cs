//PROJECT NAME: CSICustomer
//CLASS NAME: CoStatusChangeValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoStatusChangeValidFactory
	{
		public ICoStatusChangeValid Create(IApplicationDB appDB)
		{
			var _CoStatusChangeValid = new Logistics.Customer.CoStatusChangeValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoStatusChangeValidExt = timerfactory.Create<Logistics.Customer.ICoStatusChangeValid>(_CoStatusChangeValid);
			
			return iCoStatusChangeValidExt;
		}
	}
}
