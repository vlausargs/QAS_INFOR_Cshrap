//PROJECT NAME: Production
//CLASS NAME: CLM_JobCustomersFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class CLM_JobCustomersFactory
	{
		public ICLM_JobCustomers Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_JobCustomers = new Production.CLM_JobCustomers(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_JobCustomersExt = timerfactory.Create<Production.ICLM_JobCustomers>(_CLM_JobCustomers);
			
			return iCLM_JobCustomersExt;
		}
	}
}
