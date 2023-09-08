//PROJECT NAME: CSIMaterial
//CLASS NAME: AU_CheckAvaiableParentContainersFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class AU_CheckAvaiableParentContainersFactory
	{
		public IAU_CheckAvaiableParentContainers Create(IApplicationDB appDB)
		{
			var _AU_CheckAvaiableParentContainers = new Material.AU_CheckAvaiableParentContainers(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_CheckAvaiableParentContainersExt = timerfactory.Create<Material.IAU_CheckAvaiableParentContainers>(_AU_CheckAvaiableParentContainers);
			
			return iAU_CheckAvaiableParentContainersExt;
		}
	}
}
