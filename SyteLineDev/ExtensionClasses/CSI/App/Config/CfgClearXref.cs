//PROJECT NAME: Config
//CLASS NAME: CfgClearXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgClearXref : ICfgClearXref
	{
		readonly IApplicationDB appDB;
		
		public CfgClearXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? pAbort,
			string Infobar) CfgClearXrefSp(
			string pFromSite,
			string pRefNum,
			int? pRefLine,
			string pCoNum,
			int? pCoLine,
			int? pCoRelease,
			int? pAbort,
			string Infobar)
		{
			SiteType _pFromSite = pFromSite;
			JobPoProjReqTrnNumType _pRefNum = pRefNum;
			SuffixPoLineProjTaskReqTrnLineType _pRefLine = pRefLine;
			CoNumType _pCoNum = pCoNum;
			CoLineType _pCoLine = pCoLine;
			CoReleaseType _pCoRelease = pCoRelease;
			FlagNyType _pAbort = pAbort;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgClearXrefSp";
				
				appDB.AddCommandParameter(cmd, "pFromSite", _pFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRefNum", _pRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRefLine", _pRefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoLine", _pCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoRelease", _pCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAbort", _pAbort, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pAbort = _pAbort;
				Infobar = _Infobar;
				
				return (Severity, pAbort, Infobar);
			}
		}
	}
}
