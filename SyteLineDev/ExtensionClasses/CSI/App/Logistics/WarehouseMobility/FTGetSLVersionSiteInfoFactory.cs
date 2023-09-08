//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTGetSLVersionSiteInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTGetSLVersionSiteInfoFactory
	{
		public IFTGetSLVersionSiteInfo Create(IApplicationDB appDB)
		{
			var _FTGetSLVersionSiteInfo = new Logistics.WarehouseMobility.FTGetSLVersionSiteInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTGetSLVersionSiteInfoExt = timerfactory.Create<Logistics.WarehouseMobility.IFTGetSLVersionSiteInfo>(_FTGetSLVersionSiteInfo);
			
			return iFTGetSLVersionSiteInfoExt;
		}
	}
}
