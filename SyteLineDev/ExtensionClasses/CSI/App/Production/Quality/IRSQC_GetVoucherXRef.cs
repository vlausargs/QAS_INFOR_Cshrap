//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetVoucherXRef.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetVoucherXRef
	{
		(int? ReturnCode, int? o_voucher,
		string Infobar) RSQC_GetVoucherXRefSp(int? i_vrma,
		int? o_voucher,
		string Infobar);
	}
}

