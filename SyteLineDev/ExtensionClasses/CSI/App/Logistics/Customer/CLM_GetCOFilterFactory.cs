//PROJECT NAME: Logistics
//CLASS NAME: CLM_GetCOFilterFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_GetCOFilterFactory
	{
		public ICLM_GetCOFilter Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetCOFilter = new Logistics.Customer.CLM_GetCOFilter(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetCOFilterExt = timerfactory.Create<Logistics.Customer.ICLM_GetCOFilter>(_CLM_GetCOFilter);
			
			return iCLM_GetCOFilterExt;
		}
	}
}
