//PROJECT NAME: Logistics
//CLASS NAME: SSSFSKbaseSearchFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSKbaseSearchFactory
	{
		public ISSSFSKbaseSearch Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSKbaseSearch = new Logistics.FieldService.CallCenter.SSSFSKbaseSearch(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSKbaseSearchExt = timerfactory.Create<Logistics.FieldService.CallCenter.ISSSFSKbaseSearch>(_SSSFSKbaseSearch);
			
			return iSSSFSKbaseSearchExt;
		}
	}
}
