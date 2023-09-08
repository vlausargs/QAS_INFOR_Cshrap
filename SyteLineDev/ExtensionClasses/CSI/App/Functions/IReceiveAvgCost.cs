//PROJECT NAME: Data
//CLASS NAME: IReceiveAvgCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IReceiveAvgCost
	{
		decimal? ReceiveAvgCostFn(
			decimal? ICost,
			decimal? MCost,
			decimal? Quantity,
			decimal? Sum);
	}
}

