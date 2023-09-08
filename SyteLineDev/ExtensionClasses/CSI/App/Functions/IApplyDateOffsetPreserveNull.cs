//PROJECT NAME: Data
//CLASS NAME: IApplyDateOffsetPreserveNull.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IApplyDateOffsetPreserveNull
	{
		(int? ReturnCode,
			DateTime? Date) ApplyDateOffsetPreserveNullSp(
			DateTime? Date,
			int? Offset = null,
			int? IsEndDate = null);
	}
}

