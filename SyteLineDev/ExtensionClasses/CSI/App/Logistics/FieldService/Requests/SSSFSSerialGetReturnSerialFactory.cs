//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSerialGetReturnSerialFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSerialGetReturnSerialFactory
	{
		public ISSSFSSerialGetReturnSerial Create(IApplicationDB appDB)
		{
			var _SSSFSSerialGetReturnSerial = new Logistics.FieldService.Requests.SSSFSSerialGetReturnSerial(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSerialGetReturnSerialExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSerialGetReturnSerial>(_SSSFSSerialGetReturnSerial);
			
			return iSSSFSSerialGetReturnSerialExt;
		}
	}
}
