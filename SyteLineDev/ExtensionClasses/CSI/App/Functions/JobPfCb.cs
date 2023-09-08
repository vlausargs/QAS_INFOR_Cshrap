//PROJECT NAME: Data
//CLASS NAME: JobPfCb.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobPfCb : IJobPfCb
	{
		readonly IApplicationDB appDB;
		
		public JobPfCb(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) JobPfCbSp(
			decimal? CurTransNum,
			string TWc,
			Guid? SessionId,
			int? pPostNeg,
			string Infobar,
			string DocumentNum = null)
		{
			HugeTransNumType _CurTransNum = CurTransNum;
			WcType _TWc = TWc;
			RowPointerType _SessionId = SessionId;
			Flag _pPostNeg = pPostNeg;
			InfobarType _Infobar = Infobar;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobPfCbSp";
				
				appDB.AddCommandParameter(cmd, "CurTransNum", _CurTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TWc", _TWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPostNeg", _pPostNeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
