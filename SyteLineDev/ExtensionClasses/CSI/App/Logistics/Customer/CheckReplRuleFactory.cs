//PROJECT NAME: CSICustomer
//CLASS NAME: CheckReplRuleFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CheckReplRuleFactory
	{
		public ICheckReplRule Create(IApplicationDB appDB)
		{
			var _CheckReplRule = new Logistics.Customer.CheckReplRule(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckReplRuleExt = timerfactory.Create<Logistics.Customer.ICheckReplRule>(_CheckReplRule);
			
			return iCheckReplRuleExt;
		}
	}
}
