//PROJECT NAME: Production
//CLASS NAME: JobJobPJobtPcI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobJobPJobtPcI : IJobJobPJobtPcI
	{
		readonly IApplicationDB appDB;
		
		
		public JobJobPJobtPcI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) JobJobPJobtPcISp(decimal? pTransNum,
		Guid? SessionId,
		string Infobar)
		{
			HugeTransNumType _pTransNum = pTransNum;
			RowPointerType _SessionId = SessionId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobJobPJobtPcISp";
				
				appDB.AddCommandParameter(cmd, "pTransNum", _pTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
