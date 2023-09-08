//PROJECT NAME: Production
//CLASS NAME: ISyncJobSubJobDueDates.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ISyncJobSubJobDueDates
	{
		(int? ReturnCode, string Infobar) SyncJobSubJobDueDatesSp(string PJob,
		int? PSuffix,
		int? PPerformSync,
		int? POverwriteDates,
		string Infobar);
	}
}

