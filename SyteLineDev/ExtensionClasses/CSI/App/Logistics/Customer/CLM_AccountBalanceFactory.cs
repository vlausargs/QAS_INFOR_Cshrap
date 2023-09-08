//PROJECT NAME: Logistics
//CLASS NAME: CLM_AccountBalanceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_AccountBalanceFactory
	{
		public ICLM_AccountBalance Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_AccountBalance = new Logistics.Customer.CLM_AccountBalance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_AccountBalanceExt = timerfactory.Create<Logistics.Customer.ICLM_AccountBalance>(_CLM_AccountBalance);
			
			return iCLM_AccountBalanceExt;
		}
	}
}
