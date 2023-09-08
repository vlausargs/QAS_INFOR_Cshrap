//PROJECT NAME: Logistics
//CLASS NAME: ImportVATManagerFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ImportVATManagerFactory
	{
		public IImportVATManager Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ImportVATManager = new Logistics.Customer.ImportVATManager(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iImportVATManagerExt = timerfactory.Create<Logistics.Customer.IImportVATManager>(_ImportVATManager);
			
			return iImportVATManagerExt;
		}
	}
}
