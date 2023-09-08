//PROJECT NAME: Production
//CLASS NAME: IJobStatusChangeMassStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobStatusChangeMassStatus
	{
		(int? ReturnCode,
			int? Sequence) JobStatusChangeMassStatusSp(
			int? Commit,
			string JobJob,
			int? JobSuffix,
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

