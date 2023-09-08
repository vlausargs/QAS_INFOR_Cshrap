//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_ExecutiveOppWonLostFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_ExecutiveOppWonLostFactory
	{
		public IHomepage_ExecutiveOppWonLost Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_ExecutiveOppWonLost = new Logistics.Customer.Homepage_ExecutiveOppWonLost(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_ExecutiveOppWonLostExt = timerfactory.Create<Logistics.Customer.IHomepage_ExecutiveOppWonLost>(_Homepage_ExecutiveOppWonLost);
			
			return iHomepage_ExecutiveOppWonLostExt;
		}
	}
}
