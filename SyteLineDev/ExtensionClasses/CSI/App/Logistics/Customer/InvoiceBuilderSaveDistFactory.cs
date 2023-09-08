//PROJECT NAME: Logistics
//CLASS NAME: InvoiceBuilderSaveDistFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class InvoiceBuilderSaveDistFactory
	{
		public IInvoiceBuilderSaveDist Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InvoiceBuilderSaveDist = new Logistics.Customer.InvoiceBuilderSaveDist(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvoiceBuilderSaveDistExt = timerfactory.Create<Logistics.Customer.IInvoiceBuilderSaveDist>(_InvoiceBuilderSaveDist);
			
			return iInvoiceBuilderSaveDistExt;
		}
	}
}
