//PROJECT NAME: Logistics
//CLASS NAME: Home_CashImpactFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Home_CashImpactFactory
	{
		public IHome_CashImpact Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_CashImpact = new Logistics.Customer.Home_CashImpact(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_CashImpactExt = timerfactory.Create<Logistics.Customer.IHome_CashImpact>(_Home_CashImpact);
			
			return iHome_CashImpactExt;
		}
	}
}
