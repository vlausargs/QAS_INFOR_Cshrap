//PROJECT NAME: Material
//CLASS NAME: AU_AddParentContainerFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class AU_AddParentContainerFactory
	{
		public IAU_AddParentContainer Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AU_AddParentContainer = new Material.AU_AddParentContainer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_AddParentContainerExt = timerfactory.Create<Material.IAU_AddParentContainer>(_AU_AddParentContainer);
			
			return iAU_AddParentContainerExt;
		}
	}
}
