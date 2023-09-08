//PROJECT NAME: Logistics
//CLASS NAME: Homepage_CODocLifecycleDocumentFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_CODocLifecycleDocumentFactory
	{
		public IHomepage_CODocLifecycleDocument Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_CODocLifecycleDocument = new Logistics.Customer.Homepage_CODocLifecycleDocument(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_CODocLifecycleDocumentExt = timerfactory.Create<Logistics.Customer.IHomepage_CODocLifecycleDocument>(_Homepage_CODocLifecycleDocument);
			
			return iHomepage_CODocLifecycleDocumentExt;
		}
	}
}
