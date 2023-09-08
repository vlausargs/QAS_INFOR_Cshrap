//PROJECT NAME: CSIMaterial
//CLASS NAME: AU_ValidateContainerFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class AU_ValidateContainerFactory
	{
		public IAU_ValidateContainer Create(IApplicationDB appDB)
		{
			var _AU_ValidateContainer = new Material.AU_ValidateContainer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_ValidateContainerExt = timerfactory.Create<Material.IAU_ValidateContainer>(_AU_ValidateContainer);
			
			return iAU_ValidateContainerExt;
		}
	}
}
