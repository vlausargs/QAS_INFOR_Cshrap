//PROJECT NAME: CSICustomer
//CLASS NAME: GetInteractionRefRowPointerFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetInteractionRefRowPointerFactory
	{
		public IGetInteractionRefRowPointer Create(IApplicationDB appDB)
		{
			var _GetInteractionRefRowPointer = new Logistics.Customer.GetInteractionRefRowPointer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetInteractionRefRowPointerExt = timerfactory.Create<Logistics.Customer.IGetInteractionRefRowPointer>(_GetInteractionRefRowPointer);
			
			return iGetInteractionRefRowPointerExt;
		}
	}
}
