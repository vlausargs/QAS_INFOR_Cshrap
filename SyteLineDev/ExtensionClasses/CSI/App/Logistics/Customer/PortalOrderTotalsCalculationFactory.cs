//PROJECT NAME: CSICustomer
//CLASS NAME: PortalOrderTotalsCalculationFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PortalOrderTotalsCalculationFactory
	{
		public IPortalOrderTotalsCalculation Create(IApplicationDB appDB)
		{
			var _PortalOrderTotalsCalculation = new Logistics.Customer.PortalOrderTotalsCalculation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortalOrderTotalsCalculationExt = timerfactory.Create<Logistics.Customer.IPortalOrderTotalsCalculation>(_PortalOrderTotalsCalculation);
			
			return iPortalOrderTotalsCalculationExt;
		}
	}
}
