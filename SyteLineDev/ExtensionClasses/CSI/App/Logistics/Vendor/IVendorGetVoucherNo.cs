//PROJECT NAME: Logistics
//CLASS NAME: IVendorGetVoucherNo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVendorGetVoucherNo
	{
		(int? ReturnCode, int? RVoucher,
		string RRef,
		string Infobar) VendorGetVoucherNoSp(int? RVoucher,
		string RRef,
		string Infobar);
	}
}

