//PROJECT NAME: Logistics
//CLASS NAME: IVendorGetVoucherAdjDistTtl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVendorGetVoucherAdjDistTtl
	{
		(int? ReturnCode, decimal? TDistTotal,
		string Infobar) VendorGetVoucherAdjDistTtlSp(string TVendNum,
		int? TVoucher,
		decimal? TDistTotal,
		string Infobar);
	}
}

