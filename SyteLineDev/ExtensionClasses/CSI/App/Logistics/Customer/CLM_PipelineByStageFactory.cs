//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_PipelineByStageFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_PipelineByStageFactory
	{
		public ICLM_PipelineByStage Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PipelineByStage = new Logistics.Customer.CLM_PipelineByStage(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PipelineByStageExt = timerfactory.Create<Logistics.Customer.ICLM_PipelineByStage>(_CLM_PipelineByStage);
			
			return iCLM_PipelineByStageExt;
		}
	}
}
