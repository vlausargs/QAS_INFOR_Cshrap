//PROJECT NAME: CSIMaterial
//CLASS NAME: GetItemlocQtyFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class GetItemlocQtyFactory
	{
		public IGetItemlocQty Create(IApplicationDB appDB)
		{
			var _GetItemlocQty = new Material.GetItemlocQty(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetItemlocQtyExt = timerfactory.Create<Material.IGetItemlocQty>(_GetItemlocQty);
			
			return iGetItemlocQtyExt;
		}
	}
}
