//PROJECT NAME: Config
//CLASS NAME: CfgDelXrefJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgDelXrefJob : ICfgDelXrefJob
	{
		readonly IApplicationDB appDB;
		
		public CfgDelXrefJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CfgDelXrefJobSp(
			string pCoNum,
			int? pCoLine,
			int? pCoRelease,
			string Infobar)
		{
			CoNumType _pCoNum = pCoNum;
			CoLineType _pCoLine = pCoLine;
			CoReleaseType _pCoRelease = pCoRelease;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgDelXrefJobSp";
				
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoLine", _pCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoRelease", _pCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
