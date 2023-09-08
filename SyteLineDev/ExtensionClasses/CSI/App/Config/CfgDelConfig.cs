//PROJECT NAME: Config
//CLASS NAME: CfgDelConfig.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgDelConfig : ICfgDelConfig
	{
		readonly IApplicationDB appDB;
		
		public CfgDelConfig(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CfgDelConfigSp(
			string pDeleteFrom,
			string pConfigId,
			string Infobar)
		{
			StringType _pDeleteFrom = pDeleteFrom;
			ConfigIdType _pConfigId = pConfigId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgDelConfigSp";
				
				appDB.AddCommandParameter(cmd, "pDeleteFrom", _pDeleteFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pConfigId", _pConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
