//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetAllNotesFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetAllNotesFactory
	{
		public ISSSFSGetAllNotes Create(IApplicationDB appDB)
		{
			var _SSSFSGetAllNotes = new Logistics.FieldService.SSSFSGetAllNotes(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSGetAllNotesExt = timerfactory.Create<Logistics.FieldService.ISSSFSGetAllNotes>(_SSSFSGetAllNotes);
			
			return iSSSFSGetAllNotesExt;
		}
	}
}
