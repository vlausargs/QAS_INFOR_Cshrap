//PROJECT NAME: Config
//CLASS NAME: CfgRepRemoteConfig.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgRepRemoteConfig : ICfgRepRemoteConfig
	{
		readonly IApplicationDB appDB;
		
		public CfgRepRemoteConfig(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CfgRepRemoteConfigSp(
			string pFromSite,
			string pFromCoNum,
			int? pFromCoLine,
			int? pFromCoRelease,
			string Infobar)
		{
			SiteType _pFromSite = pFromSite;
			CoNumType _pFromCoNum = pFromCoNum;
			CoLineType _pFromCoLine = pFromCoLine;
			CoReleaseType _pFromCoRelease = pFromCoRelease;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgRepRemoteConfigSp";
				
				appDB.AddCommandParameter(cmd, "pFromSite", _pFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFromCoNum", _pFromCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFromCoLine", _pFromCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFromCoRelease", _pFromCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
