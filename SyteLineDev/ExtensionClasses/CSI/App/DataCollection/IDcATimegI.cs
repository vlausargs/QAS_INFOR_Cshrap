//PROJECT NAME: DataCollection
//CLASS NAME: IDcATimegI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcATimegI
	{
		(int? ReturnCode,
			DateTime? PPostDate,
			int? PPostTime) DcATimegISp(
			DateTime? ShiftTime,
			int? GraceInOut1,
			int? GraceInOut2,
			DateTime? TShiftDate,
			DateTime? PPostDate,
			int? PPostTime);
	}
}

