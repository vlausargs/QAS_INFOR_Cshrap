//PROJECT NAME: Data
//CLASS NAME: ITestItemlifoBreakout.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITestItemlifoBreakout
	{
		(int? ReturnCode,
			decimal? ItemlifoStackRemaining,
			decimal? WhseQtyRemaining) TestItemlifoBreakoutSp(
			Guid? ItemlifoRowPointer,
			string Whse,
			decimal? PercentageOfInventory,
			int? AllowRemainder,
			int? SecondPass,
			decimal? ItemlifoStackRemaining,
			decimal? WhseQtyRemaining);
	}
}

