//PROJECT NAME: CSIFinance
//CLASS NAME: CLM_ExecutivePipelineFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class CLM_ExecutivePipelineFactory
	{
		public ICLM_ExecutivePipeline Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ExecutivePipeline = new Finance.CLM_ExecutivePipeline(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ExecutivePipelineExt = timerfactory.Create<Finance.ICLM_ExecutivePipeline>(_CLM_ExecutivePipeline);
			
			return iCLM_ExecutivePipelineExt;
		}
	}
}
