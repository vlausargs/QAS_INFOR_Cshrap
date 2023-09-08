//PROJECT NAME: Production
//CLASS NAME: JobtClsLogError.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobtClsLogError : IJobtClsLogError
	{
		readonly IApplicationDB appDB;
		
		
		public JobtClsLogError(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? JobtClsLogErrorSp(decimal? PTransNum,
		string ErrorMsg)
		{
			HugeTransNumType _PTransNum = PTransNum;
			InfobarType _ErrorMsg = ErrorMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobtClsLogErrorSp";
				
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorMsg", _ErrorMsg, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
