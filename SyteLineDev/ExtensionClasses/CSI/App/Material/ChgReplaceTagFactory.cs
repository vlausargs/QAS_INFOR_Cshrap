//PROJECT NAME: CSIMaterial
//CLASS NAME: ChgReplaceTagFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ChgReplaceTagFactory
	{
		public IChgReplaceTag Create(IApplicationDB appDB)
		{
			var _ChgReplaceTag = new Material.ChgReplaceTag(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChgReplaceTagExt = timerfactory.Create<Material.IChgReplaceTag>(_ChgReplaceTag);
			
			return iChgReplaceTagExt;
		}
	}
}
