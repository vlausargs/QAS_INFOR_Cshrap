//PROJECT NAME: Material
//CLASS NAME: RebalItemAllocToOrderFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class RebalItemAllocToOrderFactory
	{
		public IRebalItemAllocToOrder Create(IApplicationDB appDB)
		{
			var _RebalItemAllocToOrder = new Material.RebalItemAllocToOrder(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRebalItemAllocToOrderExt = timerfactory.Create<Material.IRebalItemAllocToOrder>(_RebalItemAllocToOrder);
			
			return iRebalItemAllocToOrderExt;
		}
	}
}
