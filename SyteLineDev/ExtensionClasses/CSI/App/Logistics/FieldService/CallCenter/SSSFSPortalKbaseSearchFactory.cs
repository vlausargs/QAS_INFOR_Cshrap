//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPortalKbaseSearchFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSPortalKbaseSearchFactory
	{
		public ISSSFSPortalKbaseSearch Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSPortalKbaseSearch = new Logistics.FieldService.CallCenter.SSSFSPortalKbaseSearch(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSPortalKbaseSearchExt = timerfactory.Create<Logistics.FieldService.CallCenter.ISSSFSPortalKbaseSearch>(_SSSFSPortalKbaseSearch);
			
			return iSSSFSPortalKbaseSearchExt;
		}
	}
}
