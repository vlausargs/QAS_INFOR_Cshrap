//PROJECT NAME: CSICustomer
//CLASS NAME: GetInteractionCountFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetInteractionCountFactory
	{
		public IGetInteractionCount Create(IApplicationDB appDB)
		{
			var _GetInteractionCount = new Logistics.Customer.GetInteractionCount(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetInteractionCountExt = timerfactory.Create<Logistics.Customer.IGetInteractionCount>(_GetInteractionCount);
			
			return iGetInteractionCountExt;
		}
	}
}
