//PROJECT NAME: Logistics
//CLASS NAME: RmaReplFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaReplFactory
	{
		public IRmaRepl Create(IApplicationDB appDB)
		{
			var _RmaRepl = new Logistics.Customer.RmaRepl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRmaReplExt = timerfactory.Create<Logistics.Customer.IRmaRepl>(_RmaRepl);
			
			return iRmaReplExt;
		}
	}
}
