//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedTeamLoadConflictFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedTeamLoadConflictFactory
	{
		public ISSSFSSchedTeamLoadConflict Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSSchedTeamLoadConflict = new Logistics.FieldService.Partner.SSSFSSchedTeamLoadConflict(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSchedTeamLoadConflictExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSSchedTeamLoadConflict>(_SSSFSSchedTeamLoadConflict);
			
			return iSSSFSSchedTeamLoadConflictExt;
		}
	}
}
