//PROJECT NAME: Config
//CLASS NAME: CfgGetCoNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgGetCoNum : ICfgGetCoNum
	{
		readonly IApplicationDB appDB;
		
		
		public CfgGetCoNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CoNum,
		int? CoLine,
		string Infobar) CfgGetCoNumSp(string ConfigId,
		string CoNum,
		int? CoLine,
		string Infobar)
		{
			ConfigIdType _ConfigId = ConfigId;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgGetCoNumSp";
				
				appDB.AddCommandParameter(cmd, "ConfigId", _ConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoNum = _CoNum;
				CoLine = _CoLine;
				Infobar = _Infobar;
				
				return (Severity, CoNum, CoLine, Infobar);
			}
		}
	}
}
