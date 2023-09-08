//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_CustomerOrderKitBuilderFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_CustomerOrderKitBuilderFactory
	{
		public ICLM_CustomerOrderKitBuilder Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_CustomerOrderKitBuilder = new Logistics.Customer.CLM_CustomerOrderKitBuilder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_CustomerOrderKitBuilderExt = timerfactory.Create<Logistics.Customer.ICLM_CustomerOrderKitBuilder>(_CLM_CustomerOrderKitBuilder);
			
			return iCLM_CustomerOrderKitBuilderExt;
		}
	}
}
