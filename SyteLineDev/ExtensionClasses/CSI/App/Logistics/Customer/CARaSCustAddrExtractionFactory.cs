//PROJECT NAME: Logistics
//CLASS NAME: CARaSCustAddrExtractionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CARaSCustAddrExtractionFactory
	{
		public ICARaSCustAddrExtraction Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CARaSCustAddrExtraction = new Logistics.Customer.CARaSCustAddrExtraction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCARaSCustAddrExtractionExt = timerfactory.Create<Logistics.Customer.ICARaSCustAddrExtraction>(_CARaSCustAddrExtraction);
			
			return iCARaSCustAddrExtractionExt;
		}
	}
}
