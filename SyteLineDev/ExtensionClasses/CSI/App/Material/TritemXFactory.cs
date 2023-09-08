//PROJECT NAME: CSIMaterial
//CLASS NAME: TritemXFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class TritemXFactory
	{
		public ITritemX Create(IApplicationDB appDB)
		{
			var _TritemX = new Material.TritemX(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTritemXExt = timerfactory.Create<Material.ITritemX>(_TritemX);
			
			return iTritemXExt;
		}
	}
}
