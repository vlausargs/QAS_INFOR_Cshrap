//PROJECT NAME: Logistics
//CLASS NAME: SSSFSProfileSROPrePackSlipFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSProfileSROPrePackSlipFactory
	{
		public ISSSFSProfileSROPrePackSlip Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSProfileSROPrePackSlip = new Logistics.FieldService.Requests.SSSFSProfileSROPrePackSlip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSProfileSROPrePackSlipExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSProfileSROPrePackSlip>(_SSSFSProfileSROPrePackSlip);
			
			return iSSSFSProfileSROPrePackSlipExt;
		}
	}
}
