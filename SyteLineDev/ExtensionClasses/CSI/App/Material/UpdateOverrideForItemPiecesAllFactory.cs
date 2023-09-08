//PROJECT NAME: Material
//CLASS NAME: UpdateOverrideForItemPiecesAllFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class UpdateOverrideForItemPiecesAllFactory
	{
		public IUpdateOverrideForItemPiecesAll Create(IApplicationDB appDB)
		{
			var _UpdateOverrideForItemPiecesAll = new Material.UpdateOverrideForItemPiecesAll(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateOverrideForItemPiecesAllExt = timerfactory.Create<Material.IUpdateOverrideForItemPiecesAll>(_UpdateOverrideForItemPiecesAll);
			
			return iUpdateOverrideForItemPiecesAllExt;
		}
	}
}
