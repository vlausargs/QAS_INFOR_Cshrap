//PROJECT NAME: Logistics
//CLASS NAME: DeletePickListRefFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class DeletePickListRefFactory
	{
		public IDeletePickListRef Create(IApplicationDB appDB)
		{
			var _DeletePickListRef = new Logistics.Customer.DeletePickListRef(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeletePickListRefExt = timerfactory.Create<Logistics.Customer.IDeletePickListRef>(_DeletePickListRef);
			
			return iDeletePickListRefExt;
		}
	}
}
