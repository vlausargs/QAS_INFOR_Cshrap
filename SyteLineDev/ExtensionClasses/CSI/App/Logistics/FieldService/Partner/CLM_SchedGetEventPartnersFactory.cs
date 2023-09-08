//PROJECT NAME: Logistics
//CLASS NAME: CLM_SchedGetEventPartnersFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Partner
{
	public class CLM_SchedGetEventPartnersFactory
	{
		public ICLM_SchedGetEventPartners Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_SchedGetEventPartners = new Logistics.FieldService.Partner.CLM_SchedGetEventPartners(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_SchedGetEventPartnersExt = timerfactory.Create<Logistics.FieldService.Partner.ICLM_SchedGetEventPartners>(_CLM_SchedGetEventPartners);
			
			return iCLM_SchedGetEventPartnersExt;
		}
	}
}
