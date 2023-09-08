//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedHasConflictsFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedHasConflictsFactory
	{
		public ISSSFSSchedHasConflicts Create(IApplicationDB appDB)
		{
			var _SSSFSSchedHasConflicts = new Logistics.FieldService.Partner.SSSFSSchedHasConflicts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSchedHasConflictsExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSSchedHasConflicts>(_SSSFSSchedHasConflicts);
			
			return iSSSFSSchedHasConflictsExt;
		}
	}
}
