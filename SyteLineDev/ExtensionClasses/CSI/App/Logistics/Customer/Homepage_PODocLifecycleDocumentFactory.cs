//PROJECT NAME: Logistics
//CLASS NAME: Homepage_PODocLifecycleDocumentFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_PODocLifecycleDocumentFactory
	{
		public IHomepage_PODocLifecycleDocument Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_PODocLifecycleDocument = new Logistics.Customer.Homepage_PODocLifecycleDocument(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_PODocLifecycleDocumentExt = timerfactory.Create<Logistics.Customer.IHomepage_PODocLifecycleDocument>(_Homepage_PODocLifecycleDocument);
			
			return iHomepage_PODocLifecycleDocumentExt;
		}
	}
}
