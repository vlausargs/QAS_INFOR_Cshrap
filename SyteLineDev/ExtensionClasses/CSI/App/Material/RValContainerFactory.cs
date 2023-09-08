//PROJECT NAME: Material
//CLASS NAME: RValContainerFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class RValContainerFactory
	{
		public IRValContainer Create(IApplicationDB appDB)
		{
			var _RValContainer = new Material.RValContainer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRValContainerExt = timerfactory.Create<Material.IRValContainer>(_RValContainer);
			
			return iRValContainerExt;
		}
	}
}
