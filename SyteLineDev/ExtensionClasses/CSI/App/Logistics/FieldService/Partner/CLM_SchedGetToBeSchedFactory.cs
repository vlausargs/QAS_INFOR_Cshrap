//PROJECT NAME: Logistics
//CLASS NAME: CLM_SchedGetToBeSchedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Partner
{
	public class CLM_SchedGetToBeSchedFactory
	{
		public ICLM_SchedGetToBeSched Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_SchedGetToBeSched = new Logistics.FieldService.Partner.CLM_SchedGetToBeSched(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_SchedGetToBeSchedExt = timerfactory.Create<Logistics.FieldService.Partner.ICLM_SchedGetToBeSched>(_CLM_SchedGetToBeSched);
			
			return iCLM_SchedGetToBeSchedExt;
		}
	}
}
