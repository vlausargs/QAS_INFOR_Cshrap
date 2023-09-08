//PROJECT NAME: CSICustomer
//CLASS NAME: PreRmaReplFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PreRmaReplFactory
	{
		public IPreRmaRepl Create(IApplicationDB appDB)
		{
			var _PreRmaRepl = new Logistics.Customer.PreRmaRepl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPreRmaReplExt = timerfactory.Create<Logistics.Customer.IPreRmaRepl>(_PreRmaRepl);
			
			return iPreRmaReplExt;
		}
	}
}
