//PROJECT NAME: CSICustomer
//CLASS NAME: RmaItemChangeItemFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaItemChangeItemFactory
	{
		public IRmaItemChangeItem Create(IApplicationDB appDB)
		{
			var _RmaItemChangeItem = new Logistics.Customer.RmaItemChangeItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRmaItemChangeItemExt = timerfactory.Create<Logistics.Customer.IRmaItemChangeItem>(_RmaItemChangeItem);
			
			return iRmaItemChangeItemExt;
		}
	}
}
