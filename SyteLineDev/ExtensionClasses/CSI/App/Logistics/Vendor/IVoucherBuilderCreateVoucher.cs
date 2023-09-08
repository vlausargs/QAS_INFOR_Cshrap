//PROJECT NAME: Logistics
//CLASS NAME: IVoucherBuilderCreateVoucher.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVoucherBuilderCreateVoucher
	{
		(int? ReturnCode,
			int? PoVoucher,
			string Infobar) VoucherBuilderCreateVoucherSp(
			Guid? PProcessId,
			int? TVBRows,
			int? PAutoVoucher,
			int? PoVoucher = null,
			string Infobar = null);
	}
}

