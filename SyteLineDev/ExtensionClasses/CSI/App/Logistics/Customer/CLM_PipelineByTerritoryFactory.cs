//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_PipelinebyTerritoryFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_PipelinebyTerritoryFactory
	{
		public ICLM_PipelinebyTerritory Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PipelinebyTerritory = new Logistics.Customer.CLM_PipelinebyTerritory(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PipelinebyTerritoryExt = timerfactory.Create<Logistics.Customer.ICLM_PipelinebyTerritory>(_CLM_PipelinebyTerritory);
			
			return iCLM_PipelinebyTerritoryExt;
		}
	}
}
