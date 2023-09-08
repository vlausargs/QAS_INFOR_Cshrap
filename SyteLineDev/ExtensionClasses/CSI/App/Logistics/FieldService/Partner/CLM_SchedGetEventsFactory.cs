//PROJECT NAME: Logistics
//CLASS NAME: CLM_SchedGetEventsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Partner
{
	public class CLM_SchedGetEventsFactory
	{
		public ICLM_SchedGetEvents Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_SchedGetEvents = new Logistics.FieldService.Partner.CLM_SchedGetEvents(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_SchedGetEventsExt = timerfactory.Create<Logistics.FieldService.Partner.ICLM_SchedGetEvents>(_CLM_SchedGetEvents);
			
			return iCLM_SchedGetEventsExt;
		}
	}
}
