//PROJECT NAME: Logistics
//CLASS NAME: RmaReturnvFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaReturnvFactory
	{
		public IRmaReturnv Create(IApplicationDB appDB)
		{
			var _RmaReturnv = new Logistics.Customer.RmaReturnv(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRmaReturnvExt = timerfactory.Create<Logistics.Customer.IRmaReturnv>(_RmaReturnv);
			
			return iRmaReturnvExt;
		}
	}
}
