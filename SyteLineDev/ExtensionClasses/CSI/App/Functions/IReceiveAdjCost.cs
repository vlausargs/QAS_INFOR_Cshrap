//PROJECT NAME: Data
//CLASS NAME: IReceiveAdjCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IReceiveAdjCost
	{
		decimal? ReceiveAdjCostFn(
			decimal? Cost1,
			decimal? Cost2,
			decimal? Qty);
	}
}

