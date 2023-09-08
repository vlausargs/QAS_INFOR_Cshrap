//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBSupplierInvoiceHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class LoadESBSupplierInvoiceHeaderFactory
	{
		public ILoadESBSupplierInvoiceHeader Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LoadESBSupplierInvoiceHeader = new BusInterface.LoadESBSupplierInvoiceHeader(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBSupplierInvoiceHeaderExt = timerfactory.Create<BusInterface.ILoadESBSupplierInvoiceHeader>(_LoadESBSupplierInvoiceHeader);
			
			return iLoadESBSupplierInvoiceHeaderExt;
		}
	}
}
