//PROJECT NAME: Logistics
//CLASS NAME: CLM_LocalAppointmentsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Partner
{
	public class CLM_LocalAppointmentsFactory
	{
		public ICLM_LocalAppointments Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_LocalAppointments = new Logistics.FieldService.Partner.CLM_LocalAppointments(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_LocalAppointmentsExt = timerfactory.Create<Logistics.FieldService.Partner.ICLM_LocalAppointments>(_CLM_LocalAppointments);
			
			return iCLM_LocalAppointmentsExt;
		}
	}
}
