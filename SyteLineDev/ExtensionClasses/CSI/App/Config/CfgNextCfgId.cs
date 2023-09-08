//PROJECT NAME: CSIConfig
//CLASS NAME: CfgNextCfgId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Config
{
	public interface ICfgNextCfgId
	{
		int CfgNextCfgIdSp(ref string Key,
		                   ref string Infobar);
	}
	
	public class CfgNextCfgId : ICfgNextCfgId
	{
		readonly IApplicationDB appDB;
		
		public CfgNextCfgId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CfgNextCfgIdSp(ref string Key,
		                          ref string Infobar)
		{
			ConfigIdType _Key = Key;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgNextCfgIdSp";
				
				appDB.AddCommandParameter(cmd, "Key", _Key, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Key = _Key;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
