//PROJECT NAME: CSICustomer
//CLASS NAME: RMAReturnCheckFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RMAReturnCheckFactory
	{
		public IRMAReturnCheck Create(IApplicationDB appDB)
		{
			var _RMAReturnCheck = new Logistics.Customer.RMAReturnCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRMAReturnCheckExt = timerfactory.Create<Logistics.Customer.IRMAReturnCheck>(_RMAReturnCheck);
			
			return iRMAReturnCheckExt;
		}
	}
}
