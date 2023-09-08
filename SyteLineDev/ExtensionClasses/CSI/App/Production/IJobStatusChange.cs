//PROJECT NAME: Production
//CLASS NAME: IJobStatusChange.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobStatusChange
	{
		(int? ReturnCode,
			string Infobar) JobStatusChangeSp(
			string JobJob,
			int? JobSuffix,
			decimal? OldJobQtyReleased,
			string OldJobStat,
			decimal? NewJobQtyReleased,
			string NewJobStat,
			string CallFrom,
			string CurUserCode,
			string Infobar);
	}
}

