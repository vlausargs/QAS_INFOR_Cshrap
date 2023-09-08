//PROJECT NAME: Data
//CLASS NAME: IUpdResv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUpdResv
	{
		(int? ReturnCode,
			string Infobar) UpdResvSp(
			int? DelRsvd,
			Guid? RsiRowPointer,
			decimal? AdjQty,
			decimal? ConvFactor,
			string FROMBase,
			string Infobar,
			Guid? SessionID,
			int? ProcessTmpSer = 0,
			int? ClearUnusedSerials = 0,
			int? SkipInventoryUpdate = 0);
	}
}

