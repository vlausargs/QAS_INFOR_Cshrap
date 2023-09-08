//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLWMRemoveTeamMemberFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLWMRemoveTeamMemberFactory
	{
		public IFTSLWMRemoveTeamMember Create(IApplicationDB appDB)
		{
			var _FTSLWMRemoveTeamMember = new Logistics.WarehouseMobility.FTSLWMRemoveTeamMember(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLWMRemoveTeamMemberExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLWMRemoveTeamMember>(_FTSLWMRemoveTeamMember);
			
			return iFTSLWMRemoveTeamMemberExt;
		}
	}
}
