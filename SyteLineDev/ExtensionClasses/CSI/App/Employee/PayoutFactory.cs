//PROJECT NAME: CSIEmployee
//CLASS NAME: PayoutFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class PayoutFactory
	{
		public IPayout Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Payout = new Employee.Payout(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPayoutExt = timerfactory.Create<Employee.IPayout>(_Payout);
			
			return iPayoutExt;
		}
	}
}
