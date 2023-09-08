//PROJECT NAME: Logistics
//CLASS NAME: CLM_GetCustItemsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_GetCustItemsFactory
	{
		public ICLM_GetCustItems Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetCustItems = new Logistics.Customer.CLM_GetCustItems(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetCustItemsExt = timerfactory.Create<Logistics.Customer.ICLM_GetCustItems>(_CLM_GetCustItems);
			
			return iCLM_GetCustItemsExt;
		}
	}
}
