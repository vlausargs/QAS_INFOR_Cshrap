//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateLotForAttributesFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidateLotForAttributesFactory
	{
		public IFTSLValidateLotForAttributes Create(IApplicationDB appDB)
		{
			var _FTSLValidateLotForAttributes = new Logistics.WarehouseMobility.FTSLValidateLotForAttributes(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLValidateLotForAttributesExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidateLotForAttributes>(_FTSLValidateLotForAttributes);
			
			return iFTSLValidateLotForAttributesExt;
		}
	}
}
