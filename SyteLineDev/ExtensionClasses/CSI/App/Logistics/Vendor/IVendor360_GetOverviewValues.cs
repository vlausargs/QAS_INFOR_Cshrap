//PROJECT NAME: Logistics
//CLASS NAME: IVendor360_GetOverviewValues.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVendor360_GetOverviewValues
	{
		(int? ReturnCode, decimal? LateOrders,
		decimal? POFundsCommittedAmount) Vendor360_GetOverviewValuesSp(string VendorID,
		decimal? LateOrders,
		decimal? POFundsCommittedAmount);
	}
}

