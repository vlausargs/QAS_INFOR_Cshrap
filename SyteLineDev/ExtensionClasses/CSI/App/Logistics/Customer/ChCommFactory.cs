//PROJECT NAME: CSICustomer
//CLASS NAME: ChCommFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ChCommFactory
	{
		public IChComm Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ChComm = new Logistics.Customer.ChComm(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChCommExt = timerfactory.Create<Logistics.Customer.IChComm>(_ChComm);
			
			return iChCommExt;
		}
	}
}
