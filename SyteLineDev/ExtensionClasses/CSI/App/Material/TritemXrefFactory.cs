//PROJECT NAME: Material
//CLASS NAME: TritemXrefFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class TritemXrefFactory
	{
		public ITritemXref Create(IApplicationDB appDB)
		{
			var _TritemXref = new Material.TritemXref(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTritemXrefExt = timerfactory.Create<Material.ITritemXref>(_TritemXref);
			
			return iTritemXrefExt;
		}
	}
}
