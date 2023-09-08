//PROJECT NAME: Config
//CLASS NAME: CfgCreateLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgCreateLine : ICfgCreateLine
	{
		readonly IApplicationDB appDB;
		
		public CfgCreateLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CfgCreateLineSp(
			string PConfigId,
			string Infobar)
		{
			ConfigIdType _PConfigId = PConfigId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgCreateLineSp";
				
				appDB.AddCommandParameter(cmd, "PConfigId", _PConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
