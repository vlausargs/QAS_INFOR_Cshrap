//PROJECT NAME: Logistics
//CLASS NAME: CLM_GetItemsForCustItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_GetItemsForCustItemFactory
	{
		public ICLM_GetItemsForCustItem Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetItemsForCustItem = new Logistics.Customer.CLM_GetItemsForCustItem(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetItemsForCustItemExt = timerfactory.Create<Logistics.Customer.ICLM_GetItemsForCustItem>(_CLM_GetItemsForCustItem);
			
			return iCLM_GetItemsForCustItemExt;
		}
	}
}
