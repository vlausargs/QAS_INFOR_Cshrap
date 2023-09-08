//PROJECT NAME: Logistics
//CLASS NAME: CLM_InvalidDueDatePOsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_InvalidDueDatePOsFactory
	{
		public ICLM_InvalidDueDatePOs Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_InvalidDueDatePOs = new Logistics.Vendor.CLM_InvalidDueDatePOs(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_InvalidDueDatePOsExt = timerfactory.Create<Logistics.Vendor.ICLM_InvalidDueDatePOs>(_CLM_InvalidDueDatePOs);
			
			return iCLM_InvalidDueDatePOsExt;
		}
	}
}
