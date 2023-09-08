//PROJECT NAME: CSICustomer
//CLASS NAME: ItemCheckFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ItemCheckFactory
	{
		public IItemCheck Create(IApplicationDB appDB)
		{
			var _ItemCheck = new Logistics.Customer.ItemCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemCheckExt = timerfactory.Create<Logistics.Customer.IItemCheck>(_ItemCheck);
			
			return iItemCheckExt;
		}
	}
}
