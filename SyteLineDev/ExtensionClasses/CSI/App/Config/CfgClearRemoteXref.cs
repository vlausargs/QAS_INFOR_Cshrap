//PROJECT NAME: Config
//CLASS NAME: CfgClearRemoteXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgClearRemoteXref : ICfgClearRemoteXref
	{
		readonly IApplicationDB appDB;
		
		public CfgClearRemoteXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CfgClearRemoteXrefSp(
			string pRefNum,
			int? pRefLine,
			string pCoNum,
			int? pCoLine,
			int? pCoRelease)
		{
			JobPoProjReqTrnNumType _pRefNum = pRefNum;
			SuffixPoLineProjTaskReqTrnLineType _pRefLine = pRefLine;
			CoNumType _pCoNum = pCoNum;
			CoLineType _pCoLine = pCoLine;
			CoReleaseType _pCoRelease = pCoRelease;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgClearRemoteXrefSp";
				
				appDB.AddCommandParameter(cmd, "pRefNum", _pRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRefLine", _pRefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoLine", _pCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoRelease", _pCoRelease, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
