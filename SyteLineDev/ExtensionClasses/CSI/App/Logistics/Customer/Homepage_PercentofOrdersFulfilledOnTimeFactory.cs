//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_PercentofOrdersFulfilledOnTimeFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_PercentofOrdersFulfilledOnTimeFactory
	{
		public IHomepage_PercentofOrdersFulfilledOnTime Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_PercentofOrdersFulfilledOnTime = new Logistics.Customer.Homepage_PercentofOrdersFulfilledOnTime(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_PercentofOrdersFulfilledOnTimeExt = timerfactory.Create<Logistics.Customer.IHomepage_PercentofOrdersFulfilledOnTime>(_Homepage_PercentofOrdersFulfilledOnTime);
			
			return iHomepage_PercentofOrdersFulfilledOnTimeExt;
		}
	}
}
