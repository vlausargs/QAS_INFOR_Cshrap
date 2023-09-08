//PROJECT NAME: Config
//CLASS NAME: CfgCloneConfig.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgCloneConfig : ICfgCloneConfig
	{
		readonly IApplicationDB appDB;
		
		public CfgCloneConfig(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string pNewConfigGID,
			string Infobar) CfgCloneConfigSp(
			string pNewConfigID,
			string pOldConfigGID,
			string pNewConfigGID,
			string Infobar)
		{
			ConfigIdType _pNewConfigID = pNewConfigID;
			ConfigGIDType _pOldConfigGID = pOldConfigGID;
			ConfigGIDType _pNewConfigGID = pNewConfigGID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgCloneConfigSp";
				
				appDB.AddCommandParameter(cmd, "pNewConfigID", _pNewConfigID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOldConfigGID", _pOldConfigGID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNewConfigGID", _pNewConfigGID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pNewConfigGID = _pNewConfigGID;
				Infobar = _Infobar;
				
				return (Severity, pNewConfigGID, Infobar);
			}
		}
	}
}
