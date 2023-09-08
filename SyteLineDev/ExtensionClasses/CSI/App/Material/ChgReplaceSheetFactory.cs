//PROJECT NAME: CSIMaterial
//CLASS NAME: ChgReplaceSheetFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ChgReplaceSheetFactory
	{
		public IChgReplaceSheet Create(IApplicationDB appDB)
		{
			var _ChgReplaceSheet = new Material.ChgReplaceSheet(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChgReplaceSheetExt = timerfactory.Create<Material.IChgReplaceSheet>(_ChgReplaceSheet);
			
			return iChgReplaceSheetExt;
		}
	}
}
