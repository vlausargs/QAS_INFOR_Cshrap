//PROJECT NAME: Logistics
//CLASS NAME: UpdateOldInvoiceNumFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UpdateOldInvoiceNumFactory
	{
		public IUpdateOldInvoiceNum Create(IApplicationDB appDB)
		{
			var _UpdateOldInvoiceNum = new Logistics.Customer.UpdateOldInvoiceNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateOldInvoiceNumExt = timerfactory.Create<Logistics.Customer.IUpdateOldInvoiceNum>(_UpdateOldInvoiceNum);
			
			return iUpdateOldInvoiceNumExt;
		}
	}
}
