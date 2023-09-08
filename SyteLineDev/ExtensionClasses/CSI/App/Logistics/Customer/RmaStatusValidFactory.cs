//PROJECT NAME: CSICustomer
//CLASS NAME: RmaStatusValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaStatusValidFactory
	{
		public IRmaStatusValid Create(IApplicationDB appDB)
		{
			var _RmaStatusValid = new Logistics.Customer.RmaStatusValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRmaStatusValidExt = timerfactory.Create<Logistics.Customer.IRmaStatusValid>(_RmaStatusValid);
			
			return iRmaStatusValidExt;
		}
	}
}
