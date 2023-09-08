//PROJECT NAME: CSICustomer
//CLASS NAME: DoNumChangeUpdateFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class DoNumChangeUpdateFactory
	{
		public IDoNumChangeUpdate Create(IApplicationDB appDB)
		{
			var _DoNumChangeUpdate = new Logistics.Customer.DoNumChangeUpdate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDoNumChangeUpdateExt = timerfactory.Create<Logistics.Customer.IDoNumChangeUpdate>(_DoNumChangeUpdate);
			
			return iDoNumChangeUpdateExt;
		}
	}
}
