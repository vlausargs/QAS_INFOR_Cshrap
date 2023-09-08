//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_OrderShippingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_OrderShippingFactory
	{
		public ICLM_OrderShipping Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_OrderShipping = new Logistics.Customer.CLM_OrderShipping(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_OrderShippingExt = timerfactory.Create<Logistics.Customer.ICLM_OrderShipping>(_CLM_OrderShipping);
			
			return iCLM_OrderShippingExt;
		}
	}
}
