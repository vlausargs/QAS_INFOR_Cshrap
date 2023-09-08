//PROJECT NAME: Material
//CLASS NAME: RlocdefFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class RlocdefFactory
	{
		public IRlocdef Create(IApplicationDB appDB)
		{
			var _Rlocdef = new Material.Rlocdef(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRlocdefExt = timerfactory.Create<Material.IRlocdef>(_Rlocdef);
			
			return iRlocdefExt;

		}
	}
}
