//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_CustomerBalanceFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_CustomerBalanceFactory
	{
		public ICLM_CustomerBalance Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_CustomerBalance = new Logistics.Customer.CLM_CustomerBalance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_CustomerBalanceExt = timerfactory.Create<Logistics.Customer.ICLM_CustomerBalance>(_CLM_CustomerBalance);
			
			return iCLM_CustomerBalanceExt;
		}
	}
}
