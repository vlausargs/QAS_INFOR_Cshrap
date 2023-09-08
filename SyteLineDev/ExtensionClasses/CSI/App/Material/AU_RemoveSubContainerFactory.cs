//PROJECT NAME: CSIMaterial
//CLASS NAME: AU_RemoveSubContainerFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class AU_RemoveSubContainerFactory
	{
		public IAU_RemoveSubContainer Create(IApplicationDB appDB)
		{
			var _AU_RemoveSubContainer = new Material.AU_RemoveSubContainer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_RemoveSubContainerExt = timerfactory.Create<Material.IAU_RemoveSubContainer>(_AU_RemoveSubContainer);
			
			return iAU_RemoveSubContainerExt;
		}
	}
}
