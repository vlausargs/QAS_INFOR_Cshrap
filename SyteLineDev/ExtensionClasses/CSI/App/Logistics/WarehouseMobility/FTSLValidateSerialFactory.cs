//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateSerialFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidateSerialFactory
	{
		public IFTSLValidateSerial Create(IApplicationDB appDB)
		{
			var _FTSLValidateSerial = new Logistics.WarehouseMobility.FTSLValidateSerial(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLValidateSerialExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidateSerial>(_FTSLValidateSerial);
			
			return iFTSLValidateSerialExt;
		}
	}
}
