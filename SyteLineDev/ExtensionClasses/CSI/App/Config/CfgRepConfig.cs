//PROJECT NAME: Config
//CLASS NAME: CfgRepConfig.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgRepConfig : ICfgRepConfig
	{
		readonly IApplicationDB appDB;
		
		public CfgRepConfig(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? pOkFlag,
			string Infobar) CfgRepConfigSp(
			string pFromSite,
			string pToSite,
			string pCoNum,
			int? pCoLine,
			int? pCoRelease,
			string pTrnNum,
			int? pTrnLine,
			int? pOkFlag,
			string Infobar)
		{
			SiteType _pFromSite = pFromSite;
			SiteType _pToSite = pToSite;
			CoNumType _pCoNum = pCoNum;
			CoLineType _pCoLine = pCoLine;
			CoReleaseType _pCoRelease = pCoRelease;
			TrnNumType _pTrnNum = pTrnNum;
			TrnLineType _pTrnLine = pTrnLine;
			FlagNyType _pOkFlag = pOkFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgRepConfigSp";
				
				appDB.AddCommandParameter(cmd, "pFromSite", _pFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pToSite", _pToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoLine", _pCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoRelease", _pCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTrnNum", _pTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTrnLine", _pTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOkFlag", _pOkFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pOkFlag = _pOkFlag;
				Infobar = _Infobar;
				
				return (Severity, pOkFlag, Infobar);
			}
		}
	}
}
