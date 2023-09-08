//PROJECT NAME: Config
//CLASS NAME: CfgCheckRefs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgCheckRefs : ICfgCheckRefs
	{
		readonly IApplicationDB appDB;
		
		
		public CfgCheckRefs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PReconfigOk,
		string Infobar) CfgCheckRefsSp(string PConfigId,
		int? PJobFlag,
		int? PReconfigOk,
		string Infobar)
		{
			ConfigIdType _PConfigId = PConfigId;
			FlagNyType _PJobFlag = PJobFlag;
			FlagNyType _PReconfigOk = PReconfigOk;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgCheckRefsSp";
				
				appDB.AddCommandParameter(cmd, "PConfigId", _PConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobFlag", _PJobFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReconfigOk", _PReconfigOk, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PReconfigOk = _PReconfigOk;
				Infobar = _Infobar;
				
				return (Severity, PReconfigOk, Infobar);
			}
		}
	}
}
