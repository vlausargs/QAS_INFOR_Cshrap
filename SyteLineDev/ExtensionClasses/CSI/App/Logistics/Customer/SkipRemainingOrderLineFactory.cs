//PROJECT NAME: Logistics
//CLASS NAME: SkipRemainingOrderLineFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SkipRemainingOrderLineFactory
	{
		public ISkipRemainingOrderLine Create(IApplicationDB appDB)
		{
			var _SkipRemainingOrderLine = new Logistics.Customer.SkipRemainingOrderLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSkipRemainingOrderLineExt = timerfactory.Create<Logistics.Customer.ISkipRemainingOrderLine>(_SkipRemainingOrderLine);
			
			return iSkipRemainingOrderLineExt;
		}
	}
}
