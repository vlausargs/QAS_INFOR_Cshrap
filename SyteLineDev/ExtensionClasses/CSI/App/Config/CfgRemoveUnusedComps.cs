//PROJECT NAME: Config
//CLASS NAME: CfgRemoveUnusedComps.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgRemoveUnusedComps : ICfgRemoveUnusedComps
	{
		readonly IApplicationDB appDB;
		
		
		public CfgRemoveUnusedComps(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CfgRemoveUnusedCompsSp(string ConfigId,
		string CompGIDs,
		string Infobar)
		{
			ConfigIdType _ConfigId = ConfigId;
			StringType _CompGIDs = CompGIDs;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgRemoveUnusedCompsSp";
				
				appDB.AddCommandParameter(cmd, "ConfigId", _ConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompGIDs", _CompGIDs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
