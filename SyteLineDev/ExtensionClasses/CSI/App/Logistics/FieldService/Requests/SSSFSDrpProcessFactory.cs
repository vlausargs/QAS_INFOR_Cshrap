//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSDrpProcessFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSDrpProcessFactory
	{
		public ISSSFSDrpProcess Create(IApplicationDB appDB)
		{
			var _SSSFSDrpProcess = new Logistics.FieldService.Requests.SSSFSDrpProcess(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSDrpProcessExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSDrpProcess>(_SSSFSDrpProcess);
			
			return iSSSFSDrpProcessExt;
		}
	}
}
