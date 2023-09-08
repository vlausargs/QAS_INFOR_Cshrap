//PROJECT NAME: Production
//CLASS NAME: IJobStatusChange2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobStatusChange2
	{
		(int? ReturnCode,
			string Infobar) JobStatusChange2Sp(
			int? DirectClose,
			Guid? JobRowpointer,
			decimal? NewJobQtyReleased,
			decimal? QtyJustMoved,
			string NewJobStat,
			string OldJobStat,
			DateTime? TransDate,
			string CurUserCode,
			string Infobar);
	}
}

