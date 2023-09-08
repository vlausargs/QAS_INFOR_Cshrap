//PROJECT NAME: Logistics
//CLASS NAME: InvoiceTransactionFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class InvoiceTransactionFactory
	{
		public IInvoiceTransaction Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InvoiceTransaction = new Logistics.Customer.InvoiceTransaction(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvoiceTransactionExt = timerfactory.Create<Logistics.Customer.IInvoiceTransaction>(_InvoiceTransaction);
			
			return iInvoiceTransactionExt;
		}
	}
}
