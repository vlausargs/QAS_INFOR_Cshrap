//PROJECT NAME: CSICustomer
//CLASS NAME: GetMarkupFromItemFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetMarkupFromItemFactory
	{
		public IGetMarkupFromItem Create(IApplicationDB appDB)
		{
			var _GetMarkupFromItem = new Logistics.Customer.GetMarkupFromItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetMarkupFromItemExt = timerfactory.Create<Logistics.Customer.IGetMarkupFromItem>(_GetMarkupFromItem);
			
			return iGetMarkupFromItemExt;
		}
	}
}
