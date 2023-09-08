//PROJECT NAME: Material
//CLASS NAME: RloclotFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class RloclotFactory
	{
		public IRloclot Create(IApplicationDB appDB)
		{
			var _Rloclot = new Material.Rloclot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRloclotExt = timerfactory.Create<Material.IRloclot>(_Rloclot);
			
			return iRloclotExt;
		}
	}
}
