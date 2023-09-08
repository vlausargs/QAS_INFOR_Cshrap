//PROJECT NAME: Logistics
//CLASS NAME: Home_POFundsCommittedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Home_POFundsCommittedFactory
	{
		public IHome_POFundsCommitted Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_POFundsCommitted = new Logistics.Customer.Home_POFundsCommitted(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_POFundsCommittedExt = timerfactory.Create<Logistics.Customer.IHome_POFundsCommitted>(_Home_POFundsCommitted);
			
			return iHome_POFundsCommittedExt;
		}
	}
}
