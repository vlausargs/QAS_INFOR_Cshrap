//PROJECT NAME: Data
//CLASS NAME: ICalcCst.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICalcCst
	{
		(int? ReturnCode,
			decimal? OldCost,
			decimal? NewCost,
			string Infobar) CalcCstSp(
			Guid? JobRowPointer,
			int? CalcCost,
			decimal? UnitCost,
			decimal? LotCost,
			decimal? OldCost,
			decimal? NewCost,
			string Infobar);
	}
}

