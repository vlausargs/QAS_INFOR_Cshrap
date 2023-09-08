//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_OperationsEfficiencyFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_OperationsEfficiencyFactory
	{
		public IHomepage_OperationsEfficiency Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_OperationsEfficiency = new Logistics.Customer.Homepage_OperationsEfficiency(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_OperationsEfficiencyExt = timerfactory.Create<Logistics.Customer.IHomepage_OperationsEfficiency>(_Homepage_OperationsEfficiency);
			
			return iHomepage_OperationsEfficiencyExt;
		}
	}
}
