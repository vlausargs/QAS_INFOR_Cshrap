//PROJECT NAME: Logistics
//CLASS NAME: CLM_SchedGetUserPartnersFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Partner
{
	public class CLM_SchedGetUserPartnersFactory
	{
		public ICLM_SchedGetUserPartners Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_SchedGetUserPartners = new Logistics.FieldService.Partner.CLM_SchedGetUserPartners(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_SchedGetUserPartnersExt = timerfactory.Create<Logistics.FieldService.Partner.ICLM_SchedGetUserPartners>(_CLM_SchedGetUserPartners);
			
			return iCLM_SchedGetUserPartnersExt;
		}
	}
}
