//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedRescheduleLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedRescheduleLoadFactory
	{
		public ISSSFSSchedRescheduleLoad Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSSchedRescheduleLoad = new Logistics.FieldService.Partner.SSSFSSchedRescheduleLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSchedRescheduleLoadExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSSchedRescheduleLoad>(_SSSFSSchedRescheduleLoad);
			
			return iSSSFSSchedRescheduleLoadExt;
		}
	}
}
