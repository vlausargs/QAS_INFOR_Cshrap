//PROJECT NAME: Logistics
//CLASS NAME: PurgeEDIVendorShipNoticesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PurgeEDIVendorShipNoticesFactory
	{
		public IPurgeEDIVendorShipNotices Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _PurgeEDIVendorShipNotices = new Logistics.Vendor.PurgeEDIVendorShipNotices(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurgeEDIVendorShipNoticesExt = timerfactory.Create<Logistics.Vendor.IPurgeEDIVendorShipNotices>(_PurgeEDIVendorShipNotices);
			
			return iPurgeEDIVendorShipNoticesExt;
		}
	}
}
