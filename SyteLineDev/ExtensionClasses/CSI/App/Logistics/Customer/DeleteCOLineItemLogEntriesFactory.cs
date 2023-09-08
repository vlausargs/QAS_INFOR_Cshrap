//PROJECT NAME: CSICustomer
//CLASS NAME: DeleteCOLineItemLogEntriesFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class DeleteCOLineItemLogEntriesFactory
	{
		public IDeleteCOLineItemLogEntries Create(IApplicationDB appDB)
		{
			var _DeleteCOLineItemLogEntries = new Logistics.Customer.DeleteCOLineItemLogEntries(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteCOLineItemLogEntriesExt = timerfactory.Create<Logistics.Customer.IDeleteCOLineItemLogEntries>(_DeleteCOLineItemLogEntries);
			
			return iDeleteCOLineItemLogEntriesExt;
		}
	}
}
