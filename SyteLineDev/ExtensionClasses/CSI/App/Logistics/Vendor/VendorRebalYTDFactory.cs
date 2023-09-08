//PROJECT NAME: Logistics
//CLASS NAME: VendorRebalYTDFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class VendorRebalYTDFactory
	{
		public IVendorRebalYTD Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _VendorRebalYTD = new Logistics.Vendor.VendorRebalYTD(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVendorRebalYTDExt = timerfactory.Create<Logistics.Vendor.IVendorRebalYTD>(_VendorRebalYTD);
			
			return iVendorRebalYTDExt;
		}
	}
}
