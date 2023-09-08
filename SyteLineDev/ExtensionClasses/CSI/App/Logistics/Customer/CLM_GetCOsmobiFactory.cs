//PROJECT NAME: Logistics
//CLASS NAME: CLM_GetCOsmobiFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_GetCOsmobiFactory
	{
		public ICLM_GetCOsmobi Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetCOsmobi = new Logistics.Customer.CLM_GetCOsmobi(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetCOsmobiExt = timerfactory.Create<Logistics.Customer.ICLM_GetCOsmobi>(_CLM_GetCOsmobi);
			
			return iCLM_GetCOsmobiExt;
		}
	}
}
