//PROJECT NAME: Logistics
//CLASS NAME: CLM_SalespersonTop5CreditHoldFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_SalespersonTop5CreditHoldFactory
	{
		public ICLM_SalespersonTop5CreditHold Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_SalespersonTop5CreditHold = new Logistics.Customer.CLM_SalespersonTop5CreditHold(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_SalespersonTop5CreditHoldExt = timerfactory.Create<Logistics.Customer.ICLM_SalespersonTop5CreditHold>(_CLM_SalespersonTop5CreditHold);
			
			return iCLM_SalespersonTop5CreditHoldExt;
		}
	}
}
