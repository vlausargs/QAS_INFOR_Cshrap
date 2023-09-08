//PROJECT NAME: CSICustomer
//CLASS NAME: DeleteTmpPickListFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class DeleteTmpPickListFactory
	{
		public IDeleteTmpPickList Create(IApplicationDB appDB)
		{
			var _DeleteTmpPickList = new Logistics.Customer.DeleteTmpPickList(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteTmpPickListExt = timerfactory.Create<Logistics.Customer.IDeleteTmpPickList>(_DeleteTmpPickList);
			
			return iDeleteTmpPickListExt;
		}
	}
}
