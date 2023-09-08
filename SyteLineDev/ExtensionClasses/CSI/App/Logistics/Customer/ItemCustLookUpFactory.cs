//PROJECT NAME: CSICustomer
//CLASS NAME: ItemCustLookUpFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ItemCustLookUpFactory
	{
		public IItemCustLookUp Create(IApplicationDB appDB)
		{
			var _ItemCustLookUp = new Logistics.Customer.ItemCustLookUp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemCustLookUpExt = timerfactory.Create<Logistics.Customer.IItemCustLookUp>(_ItemCustLookUp);
			
			return iItemCustLookUpExt;
		}
	}
}
