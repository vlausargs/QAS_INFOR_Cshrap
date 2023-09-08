//PROJECT NAME: Logistics
//CLASS NAME: InvoiceTableUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class InvoiceTableUpdFactory
	{
		public IInvoiceTableUpd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InvoiceTableUpd = new Logistics.Customer.InvoiceTableUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvoiceTableUpdExt = timerfactory.Create<Logistics.Customer.IInvoiceTableUpd>(_InvoiceTableUpd);
			
			return iInvoiceTableUpdExt;
		}
	}
}
