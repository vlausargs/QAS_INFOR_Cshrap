//PROJECT NAME: Logistics
//CLASS NAME: RebalCustLcrFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RebalCustLcrFactory
	{
		public IRebalCustLcr Create(IApplicationDB appDB)
		{
			var _RebalCustLcr = new Logistics.Customer.RebalCustLcr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRebalCustLcrExt = timerfactory.Create<Logistics.Customer.IRebalCustLcr>(_RebalCustLcr);
			
			return iRebalCustLcrExt;
		}
	}
}
