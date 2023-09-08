//PROJECT NAME: Material
//CLASS NAME: TrnLossUMConvQtyFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class TrnLossUMConvQtyFactory
	{
		public ITrnLossUMConvQty Create(IApplicationDB appDB)
		{
			var _TrnLossUMConvQty = new Material.TrnLossUMConvQty(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTrnLossUMConvQtyExt = timerfactory.Create<Material.ITrnLossUMConvQty>(_TrnLossUMConvQty);
			
			return iTrnLossUMConvQtyExt;
		}
	}
}
