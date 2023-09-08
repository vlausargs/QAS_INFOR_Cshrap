//PROJECT NAME: Logistics
//CLASS NAME: CLM_CustomerServiceImpartFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_CustomerServiceImpartFactory
	{
		public ICLM_CustomerServiceImpart Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_CustomerServiceImpart = new Logistics.Customer.CLM_CustomerServiceImpart(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_CustomerServiceImpartExt = timerfactory.Create<Logistics.Customer.ICLM_CustomerServiceImpart>(_CLM_CustomerServiceImpart);
			
			return iCLM_CustomerServiceImpartExt;
		}
	}
}
