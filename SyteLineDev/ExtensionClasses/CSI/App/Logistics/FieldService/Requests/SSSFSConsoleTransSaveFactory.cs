//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSConsoleTransSaveFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSConsoleTransSaveFactory
	{
		public ISSSFSConsoleTransSave Create(IApplicationDB appDB)
		{
			var _SSSFSConsoleTransSave = new Logistics.FieldService.Requests.SSSFSConsoleTransSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSConsoleTransSaveExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSConsoleTransSave>(_SSSFSConsoleTransSave);
			
			return iSSSFSConsoleTransSaveExt;
		}
	}
}
