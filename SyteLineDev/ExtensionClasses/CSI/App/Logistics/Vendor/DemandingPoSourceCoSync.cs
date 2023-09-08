//PROJECT NAME: Logistics
//CLASS NAME: DemandingPoSourceCoSync.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class DemandingPoSourceCoSync : IDemandingPoSourceCoSync
	{
		readonly IApplicationDB appDB;
		
		
		public DemandingPoSourceCoSync(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DemandingPoSourceCoSyncSp(string ToSite,
		string FromSite,
		string SourceSite,
		string DemandingSite,
		string DemandingPO,
		string SourceCoNum,
		int? SourceCoLine,
		string Infobar,
		decimal? MatltranTransNum = null)
		{
			SiteType _ToSite = ToSite;
			SiteType _FromSite = FromSite;
			SiteType _SourceSite = SourceSite;
			SiteType _DemandingSite = DemandingSite;
			PoNumType _DemandingPO = DemandingPO;
			CoNumType _SourceCoNum = SourceCoNum;
			CoLineType _SourceCoLine = SourceCoLine;
			InfobarType _Infobar = Infobar;
			MatlTransNumType _MatltranTransNum = MatltranTransNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DemandingPoSourceCoSyncSp";
				
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceSite", _SourceSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandingSite", _DemandingSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandingPO", _DemandingPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceCoNum", _SourceCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceCoLine", _SourceCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatltranTransNum", _MatltranTransNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
