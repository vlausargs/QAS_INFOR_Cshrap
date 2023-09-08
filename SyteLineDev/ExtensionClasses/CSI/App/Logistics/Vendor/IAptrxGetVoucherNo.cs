//PROJECT NAME: Logistics
//CLASS NAME: IAptrxGetVoucherNo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAptrxGetVoucherNo
	{
		(int? ReturnCode, int? RVoucher,
		string RRef,
		string Infobar) AptrxGetVoucherNoSp(int? RVoucher,
		string RRef,
		string Infobar);
	}
}

