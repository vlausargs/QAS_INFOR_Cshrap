//PROJECT NAME: Material
//CLASS NAME: InsertOverrideForItemPiecesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class InsertOverrideForItemPiecesFactory
	{
		public IInsertOverrideForItemPieces Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InsertOverrideForItemPieces = new Material.InsertOverrideForItemPieces(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInsertOverrideForItemPiecesExt = timerfactory.Create<Material.IInsertOverrideForItemPieces>(_InsertOverrideForItemPieces);
			
			return iInsertOverrideForItemPiecesExt;
		}
	}
}
