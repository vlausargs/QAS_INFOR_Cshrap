//PROJECT NAME: Production
//CLASS NAME: JobStatusChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobStatusChange : IJobStatusChange
	{
		readonly IApplicationDB appDB;
		
		public JobStatusChange(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) JobStatusChangeSp(
			string JobJob,
			int? JobSuffix,
			decimal? OldJobQtyReleased,
			string OldJobStat,
			decimal? NewJobQtyReleased,
			string NewJobStat,
			string CallFrom,
			string CurUserCode,
			string Infobar)
		{
			JobType _JobJob = JobJob;
			SuffixType _JobSuffix = JobSuffix;
			QtyUnitType _OldJobQtyReleased = OldJobQtyReleased;
			JobStatusType _OldJobStat = OldJobStat;
			QtyUnitType _NewJobQtyReleased = NewJobQtyReleased;
			JobStatusType _NewJobStat = NewJobStat;
			InfobarType _CallFrom = CallFrom;
			UserCodeType _CurUserCode = CurUserCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobStatusChangeSp";
				
				appDB.AddCommandParameter(cmd, "JobJob", _JobJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldJobQtyReleased", _OldJobQtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldJobStat", _OldJobStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewJobQtyReleased", _NewJobQtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewJobStat", _NewJobStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallFrom", _CallFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurUserCode", _CurUserCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
