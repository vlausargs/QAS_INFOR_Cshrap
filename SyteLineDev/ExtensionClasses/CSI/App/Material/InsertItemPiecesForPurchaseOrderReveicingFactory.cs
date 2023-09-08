//PROJECT NAME: Material
//CLASS NAME: InsertItemPiecesForPurchaseOrderReveicingFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class InsertItemPiecesForPurchaseOrderReveicingFactory
	{
		public IInsertItemPiecesForPurchaseOrderReveicing Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InsertItemPiecesForPurchaseOrderReveicing = new Material.InsertItemPiecesForPurchaseOrderReveicing(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInsertItemPiecesForPurchaseOrderReveicingExt = timerfactory.Create<Material.IInsertItemPiecesForPurchaseOrderReveicing>(_InsertItemPiecesForPurchaseOrderReveicing);
			
			return iInsertItemPiecesForPurchaseOrderReveicingExt;
		}
	}
}
