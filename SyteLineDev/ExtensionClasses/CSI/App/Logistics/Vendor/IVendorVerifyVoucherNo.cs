//PROJECT NAME: Logistics
//CLASS NAME: IVendorVerifyVoucherNo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVendorVerifyVoucherNo
	{
		(int? ReturnCode, string Infobar) VendorVerifyVoucherNoSp(int? RVoucher,
		string Infobar);
	}
}

