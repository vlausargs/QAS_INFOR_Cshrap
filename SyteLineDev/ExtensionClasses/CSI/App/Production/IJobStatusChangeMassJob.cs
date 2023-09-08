//PROJECT NAME: Production
//CLASS NAME: IJobStatusChangeMassJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobStatusChangeMassJob
	{
		(int? ReturnCode,
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
			int? Sequence);
	}
}

