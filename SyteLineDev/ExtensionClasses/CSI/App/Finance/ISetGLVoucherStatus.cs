//PROJECT NAME: Finance
//CLASS NAME: ISetGLVoucherStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ISetGLVoucherStatus
	{
		(int? ReturnCode, string Infobar,
		int? Succ) SetGLVoucherStatusSp(string Status,
		string GLVoucher,
		string Approver = null,
		string Infobar = null,
		int? Succ = null);
	}
}

