//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSInspSignOffFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSInspSignOffFactory
	{
		public ISSSFSInspSignOff Create(IApplicationDB appDB)
		{
			var _SSSFSInspSignOff = new Logistics.FieldService.Requests.SSSFSInspSignOff(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSInspSignOffExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSInspSignOff>(_SSSFSInspSignOff);
			
			return iSSSFSInspSignOffExt;
		}
	}
}
