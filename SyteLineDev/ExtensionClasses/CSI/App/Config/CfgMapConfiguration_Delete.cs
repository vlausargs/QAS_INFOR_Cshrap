//PROJECT NAME: Config
//CLASS NAME: CfgMapConfiguration_Delete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgMapConfiguration_Delete : ICfgMapConfiguration_Delete
	{
		readonly IApplicationDB appDB;
		
		
		public CfgMapConfiguration_Delete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CfgMapConfiguration_DeleteSp(string TargetConfigID,
		string Infobar)
		{
			ConfigIdType _TargetConfigID = TargetConfigID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgMapConfiguration_DeleteSp";
				
				appDB.AddCommandParameter(cmd, "TargetConfigID", _TargetConfigID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
