//PROJECT NAME: CSIProjects
//CLASS NAME: CLM_PrjResourcesKitBuilderFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class CLM_PrjResourcesKitBuilderFactory
	{
		public ICLM_PrjResourcesKitBuilder Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PrjResourcesKitBuilder = new Production.Projects.CLM_PrjResourcesKitBuilder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PrjResourcesKitBuilderExt = timerfactory.Create<Production.Projects.ICLM_PrjResourcesKitBuilder>(_CLM_PrjResourcesKitBuilder);
			
			return iCLM_PrjResourcesKitBuilderExt;
		}
	}
}
