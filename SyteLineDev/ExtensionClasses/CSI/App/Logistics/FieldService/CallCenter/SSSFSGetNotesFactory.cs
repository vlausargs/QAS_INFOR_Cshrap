//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetNotesFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSGetNotesFactory
	{
		public ISSSFSGetNotes Create(IApplicationDB appDB)
		{
			var _SSSFSGetNotes = new Logistics.FieldService.CallCenter.SSSFSGetNotes(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSGetNotesExt = timerfactory.Create<Logistics.FieldService.CallCenter.ISSSFSGetNotes>(_SSSFSGetNotes);
			
			return iSSSFSGetNotesExt;
		}
	}
}
