//PROJECT NAME: Finance
//CLASS NAME: IAp01DbR.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AP
{
	public interface IAp01DbR
	{
		(int? ReturnCode,
			string PInvNum,
			DateTime? PInvDate,
			decimal? PInvAdj,
			string Infobar) Ap01DbRSp(
			string PSite,
			string PVendNum,
			int? PVoucher,
			string PInvNum,
			DateTime? PInvDate,
			decimal? PInvAdj,
			string Infobar);
	}
}

