//PROJECT NAME: Production
//CLASS NAME: JobtMatLogError.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobtMatLogError : IJobtMatLogError
	{
		readonly IApplicationDB appDB;
		
		
		public JobtMatLogError(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? JobtMatLogErrorSp(Guid? SessionId,
		decimal? PTransNum,
		int? PTransSeq,
		string ErrorMsg)
		{
			RowPointerType _SessionId = SessionId;
			HugeTransNumType _PTransNum = PTransNum;
			JobtranTransSeqType _PTransSeq = PTransSeq;
			InfobarType _ErrorMsg = ErrorMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobtMatLogErrorSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransSeq", _PTransSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorMsg", _ErrorMsg, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
