//PROJECT NAME: CSIMaterial
//CLASS NAME: GetVendConsignmentUsageByItemFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class GetVendConsignmentUsageByItemFactory
	{
		public IGetVendConsignmentUsageByItem Create(IApplicationDB appDB)
		{
			var _GetVendConsignmentUsageByItem = new Material.GetVendConsignmentUsageByItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetVendConsignmentUsageByItemExt = timerfactory.Create<Material.IGetVendConsignmentUsageByItem>(_GetVendConsignmentUsageByItem);
			
			return iGetVendConsignmentUsageByItemExt;
		}
	}
}
