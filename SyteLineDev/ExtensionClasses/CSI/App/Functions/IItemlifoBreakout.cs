//PROJECT NAME: Data
//CLASS NAME: IItemlifoBreakout.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemlifoBreakout
	{
		(int? ReturnCode,
			decimal? ItemlifoStackRemaining,
			decimal? WhseQtyRemaining) ItemlifoBreakoutSp(
			Guid? ItemlifoRowPointer,
			string Whse,
			decimal? PercentageOfInventory,
			int? AllowRemainder,
			int? SecondPass,
			decimal? ItemlifoStackRemaining,
			decimal? WhseQtyRemaining);
	}
}

