//PROJECT NAME: CSICustomer
//CLASS NAME: ReprintInvoiceFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ReprintInvoiceFactory
	{
		public IReprintInvoice Create(IApplicationDB appDB)
		{
			var _ReprintInvoice = new Logistics.Customer.ReprintInvoice(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iReprintInvoiceExt = timerfactory.Create<Logistics.Customer.IReprintInvoice>(_ReprintInvoice);
			
			return iReprintInvoiceExt;
		}
	}
}
