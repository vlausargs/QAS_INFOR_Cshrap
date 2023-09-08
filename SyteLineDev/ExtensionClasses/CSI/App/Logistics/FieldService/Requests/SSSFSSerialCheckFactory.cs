//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSerialCheckFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSerialCheckFactory
	{
		public ISSSFSSerialCheck Create(IApplicationDB appDB)
		{
			var _SSSFSSerialCheck = new Logistics.FieldService.Requests.SSSFSSerialCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSerialCheckExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSerialCheck>(_SSSFSSerialCheck);
			
			return iSSSFSSerialCheckExt;
		}
	}
}
