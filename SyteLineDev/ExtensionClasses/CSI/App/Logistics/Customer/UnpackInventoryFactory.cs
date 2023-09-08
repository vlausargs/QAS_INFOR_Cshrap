//PROJECT NAME: Logistics
//CLASS NAME: UnpackInventoryFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UnpackInventoryFactory
	{
		public IUnpackInventory Create(IApplicationDB appDB)
		{
			var _UnpackInventory = new Logistics.Customer.UnpackInventory(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUnpackInventoryExt = timerfactory.Create<Logistics.Customer.IUnpackInventory>(_UnpackInventory);
			
			return iUnpackInventoryExt;
		}
	}
}
