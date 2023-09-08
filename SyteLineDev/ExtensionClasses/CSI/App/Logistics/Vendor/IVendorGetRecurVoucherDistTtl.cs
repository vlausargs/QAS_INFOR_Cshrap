//PROJECT NAME: Logistics
//CLASS NAME: IVendorGetRecurVoucherDistTtl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVendorGetRecurVoucherDistTtl
	{
		(int? ReturnCode, decimal? TDistTotal,
		string Infobar) VendorGetRecurVoucherDistTtlSp(string TVendNum,
		int? TVoucher,
		decimal? TDistTotal,
		string Infobar);
	}
}

