//PROJECT NAME: Logistics
//CLASS NAME: IVoucherAllValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVoucherAllValid
	{
		(int? ReturnCode, int? Voucher,
		string Infobar) VoucherAllValidSp(int? Voucher,
		string VendNum,
		int? VouchSeq,
		string Type,
		string Infobar);
	}
}

