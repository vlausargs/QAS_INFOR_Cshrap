//PROJECT NAME: Logistics
//CLASS NAME: IVendLcrRebalance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVendLcrRebalance
	{
		(int? ReturnCode, int? VendLcrsRebalanced,
		string Infobar) VendLcrRebalanceSp(string StartingVendNum,
		string EndingVendNum,
		string StartingLcrNum,
		string EndingLcrNum,
		int? VendLcrsRebalanced,
		string Infobar);
	}
}

