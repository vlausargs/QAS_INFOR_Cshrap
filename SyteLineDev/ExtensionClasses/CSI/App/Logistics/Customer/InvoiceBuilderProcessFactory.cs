//PROJECT NAME: CSICustomer
//CLASS NAME: InvoiceBuilderProcessFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InvoiceBuilderProcessFactory
	{
		public IInvoiceBuilderProcess Create(IApplicationDB appDB)
		{
			var _InvoiceBuilderProcess = new Logistics.Customer.InvoiceBuilderProcess(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvoiceBuilderProcessExt = timerfactory.Create<Logistics.Customer.IInvoiceBuilderProcess>(_InvoiceBuilderProcess);
			
			return iInvoiceBuilderProcessExt;
		}
	}
}
