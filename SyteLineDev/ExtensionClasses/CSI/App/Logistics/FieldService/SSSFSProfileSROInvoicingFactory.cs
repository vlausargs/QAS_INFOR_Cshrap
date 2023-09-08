//PROJECT NAME: Logistics
//CLASS NAME: SSSFSProfileSROInvoicingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService
{
	public class SSSFSProfileSROInvoicingFactory
	{
		public ISSSFSProfileSROInvoicing Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSProfileSROInvoicing = new Logistics.FieldService.SSSFSProfileSROInvoicing(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSProfileSROInvoicingExt = timerfactory.Create<Logistics.FieldService.ISSSFSProfileSROInvoicing>(_SSSFSProfileSROInvoicing);
			
			return iSSSFSProfileSROInvoicingExt;
		}
	}
}
