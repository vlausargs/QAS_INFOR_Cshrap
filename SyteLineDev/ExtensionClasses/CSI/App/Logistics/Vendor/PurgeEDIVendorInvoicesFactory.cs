//PROJECT NAME: Logistics
//CLASS NAME: PurgeEDIVendorInvoicesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PurgeEDIVendorInvoicesFactory
	{
		public IPurgeEDIVendorInvoices Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PurgeEDIVendorInvoices = new Logistics.Vendor.PurgeEDIVendorInvoices(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurgeEDIVendorInvoicesExt = timerfactory.Create<Logistics.Vendor.IPurgeEDIVendorInvoices>(_PurgeEDIVendorInvoices);
			
			return iPurgeEDIVendorInvoicesExt;
		}
	}
}
