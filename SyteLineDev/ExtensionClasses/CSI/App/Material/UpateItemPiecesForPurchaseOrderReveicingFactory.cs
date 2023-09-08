//PROJECT NAME: Material
//CLASS NAME: UpateItemPiecesForPurchaseOrderReveicingFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class UpateItemPiecesForPurchaseOrderReveicingFactory
	{
		public IUpateItemPiecesForPurchaseOrderReveicing Create(IApplicationDB appDB)
		{
			var _UpateItemPiecesForPurchaseOrderReveicing = new Material.UpateItemPiecesForPurchaseOrderReveicing(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpateItemPiecesForPurchaseOrderReveicingExt = timerfactory.Create<Material.IUpateItemPiecesForPurchaseOrderReveicing>(_UpateItemPiecesForPurchaseOrderReveicing);
			
			return iUpateItemPiecesForPurchaseOrderReveicingExt;
		}
	}
}
