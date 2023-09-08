//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_CoItemsShippingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_CoItemsShippingFactory
	{
		public ICLM_CoItemsShipping Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_CoItemsShipping = new Logistics.Customer.CLM_CoItemsShipping(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_CoItemsShippingExt = timerfactory.Create<Logistics.Customer.ICLM_CoItemsShipping>(_CLM_CoItemsShipping);
			
			return iCLM_CoItemsShippingExt;
		}
	}
}
