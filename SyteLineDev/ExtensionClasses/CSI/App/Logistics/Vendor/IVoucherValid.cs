//PROJECT NAME: Logistics
//CLASS NAME: IVoucherValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVoucherValid
	{
		(int? ReturnCode, string Infobar) VoucherValidSp(int? Voucher,
		string VendNum,
		string Infobar);
	}
}

