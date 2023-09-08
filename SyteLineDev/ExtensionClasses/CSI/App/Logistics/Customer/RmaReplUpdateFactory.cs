//PROJECT NAME: Logistics
//CLASS NAME: RmaReplUpdateFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaReplUpdateFactory
	{
		public IRmaReplUpdate Create(IApplicationDB appDB)
		{
			var _RmaReplUpdate = new Logistics.Customer.RmaReplUpdate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRmaReplUpdateExt = timerfactory.Create<Logistics.Customer.IRmaReplUpdate>(_RmaReplUpdate);
			
			return iRmaReplUpdateExt;
		}
	}
}
