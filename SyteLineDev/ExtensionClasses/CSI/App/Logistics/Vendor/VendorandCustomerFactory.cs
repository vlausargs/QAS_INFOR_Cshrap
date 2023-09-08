//PROJECT NAME: Logistics
//CLASS NAME: VendorandCustomerFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class VendorandCustomerFactory
	{
		public IVendorandCustomer Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _VendorandCustomer = new Logistics.Vendor.VendorandCustomer(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVendorandCustomerExt = timerfactory.Create<Logistics.Vendor.IVendorandCustomer>(_VendorandCustomer);
			
			return iVendorandCustomerExt;
		}
	}
}
