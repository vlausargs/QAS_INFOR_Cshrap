//PROJECT NAME: Logistics
//CLASS NAME: FTSLValidateSerialNumberFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidateSerialNumberFactory
	{
		public IFTSLValidateSerialNumber Create(IApplicationDB appDB)
		{
			var _FTSLValidateSerialNumber = new Logistics.WarehouseMobility.FTSLValidateSerialNumber(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLValidateSerialNumberExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidateSerialNumber>(_FTSLValidateSerialNumber);
			
			return iFTSLValidateSerialNumberExt;
		}
	}
}
