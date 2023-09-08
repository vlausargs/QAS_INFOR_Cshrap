//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLTAGetPartnerIdFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLTAGetPartnerIdFactory
	{
		public IFTSLTAGetPartnerId Create(IApplicationDB appDB)
		{
			var _FTSLTAGetPartnerId = new Logistics.WarehouseMobility.FTSLTAGetPartnerId(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLTAGetPartnerIdExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLTAGetPartnerId>(_FTSLTAGetPartnerId);
			
			return iFTSLTAGetPartnerIdExt;
		}
	}
}
