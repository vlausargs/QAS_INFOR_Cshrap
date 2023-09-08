//PROJECT NAME: Logistics
//CLASS NAME: InvoicingBGFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class InvoicingBGFactory
	{
		public IInvoicingBG Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InvoicingBG = new Logistics.Customer.InvoicingBG(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvoicingBGExt = timerfactory.Create<Logistics.Customer.IInvoicingBG>(_InvoicingBG);
			
			return iInvoicingBGExt;
		}
	}
}
