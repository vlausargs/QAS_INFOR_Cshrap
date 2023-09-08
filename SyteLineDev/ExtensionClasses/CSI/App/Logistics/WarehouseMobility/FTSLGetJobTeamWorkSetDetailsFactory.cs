//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLGetJobTeamWorkSetDetailsFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLGetJobTeamWorkSetDetailsFactory
	{
		public IFTSLGetJobTeamWorkSetDetails Create(IApplicationDB appDB)
		{
			var _FTSLGetJobTeamWorkSetDetails = new Logistics.WarehouseMobility.FTSLGetJobTeamWorkSetDetails(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLGetJobTeamWorkSetDetailsExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLGetJobTeamWorkSetDetails>(_FTSLGetJobTeamWorkSetDetails);
			
			return iFTSLGetJobTeamWorkSetDetailsExt;
		}
	}
}
