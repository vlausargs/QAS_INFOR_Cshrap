//PROJECT NAME: Logistics
//CLASS NAME: CLM_SalespersonPipelineFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_SalespersonPipelineFactory
	{
		public ICLM_SalespersonPipeline Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_SalespersonPipeline = new Logistics.Customer.CLM_SalespersonPipeline(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_SalespersonPipelineExt = timerfactory.Create<Logistics.Customer.ICLM_SalespersonPipeline>(_CLM_SalespersonPipeline);
			
			return iCLM_SalespersonPipelineExt;
		}
	}
}
