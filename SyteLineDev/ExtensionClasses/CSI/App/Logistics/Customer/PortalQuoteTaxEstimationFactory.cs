//PROJECT NAME: CSICustomer
//CLASS NAME: PortalQuoteTaxEstimationFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PortalQuoteTaxEstimationFactory
	{
		public IPortalQuoteTaxEstimation Create(IApplicationDB appDB)
		{
			var _PortalQuoteTaxEstimation = new Logistics.Customer.PortalQuoteTaxEstimation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortalQuoteTaxEstimationExt = timerfactory.Create<Logistics.Customer.IPortalQuoteTaxEstimation>(_PortalQuoteTaxEstimation);
			
			return iPortalQuoteTaxEstimationExt;
		}
	}
}
