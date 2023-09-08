//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_FSEventFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_FSEventFactory
	{
		public ISSSFSRpt_FSEvent Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_FSEvent = new Reporting.SSSFSRpt_FSEvent(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_FSEventExt = timerfactory.Create<Reporting.ISSSFSRpt_FSEvent>(_SSSFSRpt_FSEvent);
			
			return iSSSFSRpt_FSEventExt;
		}
	}
}
