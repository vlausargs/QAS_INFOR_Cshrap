//PROJECT NAME: Logistics
//CLASS NAME: CLM_GetAPBalanceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_GetAPBalanceFactory
	{
		public ICLM_GetAPBalance Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetAPBalance = new Logistics.Customer.CLM_GetAPBalance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetAPBalanceExt = timerfactory.Create<Logistics.Customer.ICLM_GetAPBalance>(_CLM_GetAPBalance);
			
			return iCLM_GetAPBalanceExt;
		}
	}
}
