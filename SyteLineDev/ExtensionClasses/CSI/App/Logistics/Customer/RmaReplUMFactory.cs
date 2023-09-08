//PROJECT NAME: Logistics
//CLASS NAME: RmaReplUMFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaReplUMFactory
	{
		public IRmaReplUM Create(IApplicationDB appDB)
		{
			var _RmaReplUM = new Logistics.Customer.RmaReplUM(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRmaReplUMExt = timerfactory.Create<Logistics.Customer.IRmaReplUM>(_RmaReplUM);
			
			return iRmaReplUMExt;
		}
	}
}
