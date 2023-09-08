//PROJECT NAME: Data
//CLASS NAME: IApplyDateTimeOffset.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IApplyDateTimeOffset
	{
		(int? ReturnCode,
			DateTime? Date) ApplyDateTimeOffsetSp(
			DateTime? Date,
			int? Offset = null,
			int? IsEndDate = null);
	}
}

