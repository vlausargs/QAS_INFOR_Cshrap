//PROJECT NAME: Config
//CLASS NAME: CfgGetStat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgGetStat : ICfgGetStat
	{
		readonly IApplicationDB appDB;
		
		
		public CfgGetStat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ConfigStatus,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		string Infobar) CfgGetStatSp(string TrnNum,
		int? TrnLine,
		string ConfigStatus,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		string Infobar)
		{
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			ConfigStatusType _ConfigStatus = ConfigStatus;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgGetStatSp";
				
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConfigStatus", _ConfigStatus, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ConfigStatus = _ConfigStatus;
				CoNum = _CoNum;
				CoLine = _CoLine;
				CoRelease = _CoRelease;
				Infobar = _Infobar;
				
				return (Severity, ConfigStatus, CoNum, CoLine, CoRelease, Infobar);
			}
		}
	}
}
