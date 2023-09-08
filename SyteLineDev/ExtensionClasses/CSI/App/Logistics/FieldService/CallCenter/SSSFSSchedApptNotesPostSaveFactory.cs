//PROJECT NAME: CSIFSPlusCallCenter
//CLASS NAME: SSSFSSchedApptNotesPostSaveFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSSchedApptNotesPostSaveFactory
	{
		public ISSSFSSchedApptNotesPostSave Create(IApplicationDB appDB)
		{
			var _SSSFSSchedApptNotesPostSave = new Logistics.FieldService.CallCenter.SSSFSSchedApptNotesPostSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSchedApptNotesPostSaveExt = timerfactory.Create<Logistics.FieldService.CallCenter.ISSSFSSchedApptNotesPostSave>(_SSSFSSchedApptNotesPostSave);
			
			return iSSSFSSchedApptNotesPostSaveExt;
		}
	}
}
