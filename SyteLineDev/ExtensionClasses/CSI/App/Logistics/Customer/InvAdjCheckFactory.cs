//PROJECT NAME: CSICustomer
//CLASS NAME: InvAdjCheckFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InvAdjCheckFactory
	{
		public IInvAdjCheck Create(IApplicationDB appDB)
		{
			var _InvAdjCheck = new Logistics.Customer.InvAdjCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvAdjCheckExt = timerfactory.Create<Logistics.Customer.IInvAdjCheck>(_InvAdjCheck);
			
			return iInvAdjCheckExt;
		}
	}
}
