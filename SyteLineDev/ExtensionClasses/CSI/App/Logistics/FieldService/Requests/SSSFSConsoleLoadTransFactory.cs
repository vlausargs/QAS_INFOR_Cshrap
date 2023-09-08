//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConsoleLoadTransFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSConsoleLoadTransFactory
	{
		public ISSSFSConsoleLoadTrans Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSConsoleLoadTrans = new Logistics.FieldService.Requests.SSSFSConsoleLoadTrans(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSConsoleLoadTransExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSConsoleLoadTrans>(_SSSFSConsoleLoadTrans);
			
			return iSSSFSConsoleLoadTransExt;
		}
	}
}
