//PROJECT NAME: Logistics
//CLASS NAME: VendorSharedSitesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class VendorSharedSitesFactory
	{
		public IVendorSharedSites Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _VendorSharedSites = new Logistics.Customer.VendorSharedSites(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVendorSharedSitesExt = timerfactory.Create<Logistics.Customer.IVendorSharedSites>(_VendorSharedSites);
			
			return iVendorSharedSitesExt;
		}
	}
}
