//PROJECT NAME: Logistics
//CLASS NAME: ReserveFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ReserveFactory
	{
		public IReserve Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Reserve = new Logistics.Customer.Reserve(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iReserveExt = timerfactory.Create<Logistics.Customer.IReserve>(_Reserve);
			
			return iReserveExt;
		}
	}
}
