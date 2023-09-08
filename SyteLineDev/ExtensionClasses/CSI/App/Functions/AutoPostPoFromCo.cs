//PROJECT NAME: Data
//CLASS NAME: AutoPostPoFromCo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class AutoPostPoFromCo : IAutoPostPoFromCo
	{
		readonly IApplicationDB appDB;
		
		public AutoPostPoFromCo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) AutoPostPoFromCoSp(
			string ToSite,
			string FromSite,
			string DemandingPO,
			string CoNum,
			int? CoLine,
			string Infobar = null,
			decimal? MatltranTransNum = null)
		{
			SiteType _ToSite = ToSite;
			SiteType _FromSite = FromSite;
			PoNumType _DemandingPO = DemandingPO;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			Infobar _Infobar = Infobar;
			MatlTransNumType _MatltranTransNum = MatltranTransNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AutoPostPoFromCoSp";
				
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandingPO", _DemandingPO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatltranTransNum", _MatltranTransNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
