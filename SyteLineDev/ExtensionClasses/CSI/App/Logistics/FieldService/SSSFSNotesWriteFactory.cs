//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSNotesWriteFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSNotesWriteFactory
	{
		public ISSSFSNotesWrite Create(IApplicationDB appDB)
		{
			var _SSSFSNotesWrite = new Logistics.FieldService.SSSFSNotesWrite(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSNotesWriteExt = timerfactory.Create<Logistics.FieldService.ISSSFSNotesWrite>(_SSSFSNotesWrite);
			
			return iSSSFSNotesWriteExt;
		}
	}
}
