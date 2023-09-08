//PROJECT NAME: Logistics
//CLASS NAME: InvoiceBuilderDeleteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class InvoiceBuilderDeleteFactory
	{
		public IInvoiceBuilderDelete Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InvoiceBuilderDelete = new Logistics.Customer.InvoiceBuilderDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvoiceBuilderDeleteExt = timerfactory.Create<Logistics.Customer.IInvoiceBuilderDelete>(_InvoiceBuilderDelete);
			
			return iInvoiceBuilderDeleteExt;
		}
	}
}
