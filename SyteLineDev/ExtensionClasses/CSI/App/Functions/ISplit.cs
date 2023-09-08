//PROJECT NAME: Data
//CLASS NAME: ISplit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISplit
	{
		(int? ReturnCode,
			int? TTotalTime) SplitSp(
			string TEmpNum,
			string TJob,
			int? TSuffix,
			int? TOperNum,
			int? TStartTime,
			int? TEndTime,
			DateTime? TStartDate,
			DateTime? TEndDate,
			int? TTotalTime);
	}
}

