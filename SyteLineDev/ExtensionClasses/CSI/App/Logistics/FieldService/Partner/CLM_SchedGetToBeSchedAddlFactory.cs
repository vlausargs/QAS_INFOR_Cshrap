//PROJECT NAME: Logistics
//CLASS NAME: CLM_SchedGetToBeSchedAddlFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Partner
{
	public class CLM_SchedGetToBeSchedAddlFactory
	{
		public ICLM_SchedGetToBeSchedAddl Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_SchedGetToBeSchedAddl = new Logistics.FieldService.Partner.CLM_SchedGetToBeSchedAddl(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_SchedGetToBeSchedAddlExt = timerfactory.Create<Logistics.FieldService.Partner.ICLM_SchedGetToBeSchedAddl>(_CLM_SchedGetToBeSchedAddl);
			
			return iCLM_SchedGetToBeSchedAddlExt;
		}
	}
}
