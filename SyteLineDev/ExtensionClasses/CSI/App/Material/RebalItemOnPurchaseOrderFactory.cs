//PROJECT NAME: Material
//CLASS NAME: RebalItemOnPurchaseOrderFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class RebalItemOnPurchaseOrderFactory
	{
		public IRebalItemOnPurchaseOrder Create(IApplicationDB appDB)
		{
			var _RebalItemOnPurchaseOrder = new Material.RebalItemOnPurchaseOrder(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRebalItemOnPurchaseOrderExt = timerfactory.Create<Material.IRebalItemOnPurchaseOrder>(_RebalItemOnPurchaseOrder);
			
			return iRebalItemOnPurchaseOrderExt;
		}
	}
}
