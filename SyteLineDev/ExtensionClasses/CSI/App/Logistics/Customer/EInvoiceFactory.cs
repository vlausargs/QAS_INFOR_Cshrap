//PROJECT NAME: Logistics
//CLASS NAME: EInvoiceFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class EInvoiceFactory
	{
		public IEInvoice Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EInvoice = new Logistics.Customer.EInvoice(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEInvoiceExt = timerfactory.Create<Logistics.Customer.IEInvoice>(_EInvoice);
			
			return iEInvoiceExt;
		}
	}
}
