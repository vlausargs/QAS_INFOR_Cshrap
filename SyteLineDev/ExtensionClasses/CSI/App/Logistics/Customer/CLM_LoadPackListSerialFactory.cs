//PROJECT NAME: Logistics
//CLASS NAME: CLM_LoadPackListSerialFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_LoadPackListSerialFactory
	{
		public ICLM_LoadPackListSerial Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_LoadPackListSerial = new Logistics.Customer.CLM_LoadPackListSerial(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_LoadPackListSerialExt = timerfactory.Create<Logistics.Customer.ICLM_LoadPackListSerial>(_CLM_LoadPackListSerial);
			
			return iCLM_LoadPackListSerialExt;
		}
	}
}
