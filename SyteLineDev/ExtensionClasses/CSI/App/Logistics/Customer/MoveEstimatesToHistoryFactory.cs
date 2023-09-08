//PROJECT NAME: CSICustomer
//CLASS NAME: MoveEstimatesToHistoryFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class MoveEstimatesToHistoryFactory
	{
		public IMoveEstimatesToHistory Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _MoveEstimatesToHistory = new Logistics.Customer.MoveEstimatesToHistory(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMoveEstimatesToHistoryExt = timerfactory.Create<Logistics.Customer.IMoveEstimatesToHistory>(_MoveEstimatesToHistory);
			
			return iMoveEstimatesToHistoryExt;
		}
	}
}
