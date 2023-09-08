//PROJECT NAME: CSIProduct
//CLASS NAME: CLM_JobMaterialKitBuilderFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class CLM_JobMaterialKitBuilderFactory
	{
		public ICLM_JobMaterialKitBuilder Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_JobMaterialKitBuilder = new Production.CLM_JobMaterialKitBuilder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_JobMaterialKitBuilderExt = timerfactory.Create<Production.ICLM_JobMaterialKitBuilder>(_CLM_JobMaterialKitBuilder);
			
			return iCLM_JobMaterialKitBuilderExt;
		}
	}
}
