//PROJECT NAME: CSICustomer
//CLASS NAME: GetDraftAcctFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetDraftAcctFactory
	{
		public IGetDraftAcct Create(IApplicationDB appDB)
		{
			var _GetDraftAcct = new Logistics.Customer.GetDraftAcct(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetDraftAcctExt = timerfactory.Create<Logistics.Customer.IGetDraftAcct>(_GetDraftAcct);
			
			return iGetDraftAcctExt;
		}
	}
}
