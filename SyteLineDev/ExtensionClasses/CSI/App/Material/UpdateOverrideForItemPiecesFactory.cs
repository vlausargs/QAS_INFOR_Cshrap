//PROJECT NAME: Material
//CLASS NAME: UpdateOverrideForItemPiecesFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class UpdateOverrideForItemPiecesFactory
	{
		public IUpdateOverrideForItemPieces Create(IApplicationDB appDB)
		{
			var _UpdateOverrideForItemPieces = new Material.UpdateOverrideForItemPieces(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateOverrideForItemPiecesExt = timerfactory.Create<Material.IUpdateOverrideForItemPieces>(_UpdateOverrideForItemPieces);
			
			return iUpdateOverrideForItemPiecesExt;
		}
	}
}
