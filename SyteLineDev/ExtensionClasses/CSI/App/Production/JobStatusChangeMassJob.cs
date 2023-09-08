//PROJECT NAME: Production
//CLASS NAME: JobStatusChangeMassJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobStatusChangeMassJob : IJobStatusChangeMassJob
	{
		readonly IApplicationDB appDB;
		
		public JobStatusChangeMassJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? Sequence) JobStatusChangeMassJobSp(
			int? Commit,
			string JobJob,
			int? JobSuffix,
			string TopItem,
			int? DeleteHistoryJobs,
			int? SelectFinish,
			int? CopyRouting,
			string FromJobStatus,
			string ToJobStatus,
			string CurUserCode,
			DateTime? TransDate,
			int? Sequence)
		{
			IntType _Commit = Commit;
			JobType _JobJob = JobJob;
			SuffixType _JobSuffix = JobSuffix;
			ItemType _TopItem = TopItem;
			ListYesNoType _DeleteHistoryJobs = DeleteHistoryJobs;
			ListYesNoType _SelectFinish = SelectFinish;
			ListYesNoType _CopyRouting = CopyRouting;
			JobStatusType _FromJobStatus = FromJobStatus;
			JobStatusType _ToJobStatus = ToJobStatus;
			UserCodeType _CurUserCode = CurUserCode;
			DateType _TransDate = TransDate;
			IntType _Sequence = Sequence;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobStatusChangeMassJobSp";
				
				appDB.AddCommandParameter(cmd, "Commit", _Commit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobJob", _JobJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TopItem", _TopItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeleteHistoryJobs", _DeleteHistoryJobs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SelectFinish", _SelectFinish, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyRouting", _CopyRouting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJobStatus", _FromJobStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJobStatus", _ToJobStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurUserCode", _CurUserCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Sequence = _Sequence;
				
				return (Severity, Sequence);
			}
		}
	}
}
