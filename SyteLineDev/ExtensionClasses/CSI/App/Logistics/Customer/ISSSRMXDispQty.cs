//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXDispQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXDispQty
	{
		decimal? SSSRMXDispQtyFn(
			string RmaNum,
			int? RmaLine);
	}
}

