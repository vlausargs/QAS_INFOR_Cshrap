//PROJECT NAME: CSICustomer
//CLASS NAME: Home_MetricDSOFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Home_MetricDSOFactory
	{
		public IHome_MetricDSO Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_MetricDSO = new Logistics.Customer.Home_MetricDSO(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_MetricDSOExt = timerfactory.Create<Logistics.Customer.IHome_MetricDSO>(_Home_MetricDSO);
			
			return iHome_MetricDSOExt;
		}
	}
}
