//PROJECT NAME: Config
//CLASS NAME: CfgTrnXJ.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgTrnXJ : ICfgTrnXJ
	{
		readonly IApplicationDB appDB;
		
		public CfgTrnXJ(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CfgTrnXJSp(
			string pTrnNum,
			int? pTrnLine,
			string pJob,
			int? pSuffix,
			string Infobar)
		{
			TrnNumType _pTrnNum = pTrnNum;
			TrnLineType _pTrnLine = pTrnLine;
			JobType _pJob = pJob;
			SuffixType _pSuffix = pSuffix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgTrnXJSp";
				
				appDB.AddCommandParameter(cmd, "pTrnNum", _pTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTrnLine", _pTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJob", _pJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuffix", _pSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
