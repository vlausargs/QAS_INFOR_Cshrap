//PROJECT NAME: CSICustomer
//CLASS NAME: InvoiceBuilderReprintFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InvoiceBuilderReprintFactory
	{
		public IInvoiceBuilderReprint Create(IApplicationDB appDB)
		{
			var _InvoiceBuilderReprint = new Logistics.Customer.InvoiceBuilderReprint(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvoiceBuilderReprintExt = timerfactory.Create<Logistics.Customer.IInvoiceBuilderReprint>(_InvoiceBuilderReprint);
			
			return iInvoiceBuilderReprintExt;
		}
	}
}
