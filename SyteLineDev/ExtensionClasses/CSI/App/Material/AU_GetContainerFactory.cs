//PROJECT NAME: Material
//CLASS NAME: AU_GetContainerFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class AU_GetContainerFactory
	{
		public IAU_GetContainer Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _AU_GetContainer = new Material.AU_GetContainer(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_GetContainerExt = timerfactory.Create<Material.IAU_GetContainer>(_AU_GetContainer);
			
			return iAU_GetContainerExt;
		}
	}
}
