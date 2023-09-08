//PROJECT NAME: Finance
//CLASS NAME: IAP10DBR.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AP
{
	public interface IAP10DBR
	{
		(int? ReturnCode,
			string PInvNum,
			DateTime? PInvDate,
			decimal? PInvAdj,
			decimal? PAmtPaid,
			decimal? PAmtDisc,
			string PApStr,
			int? PBadVouch,
			int? PBadAp,
			int? PBadDisc,
			string Infobar) AP10DBRSP(
			string PSite,
			string PType,
			string PVendNum,
			int? PVoucher,
			string PDiscAcct,
			string PInvNum,
			DateTime? PInvDate,
			decimal? PInvAdj,
			decimal? PAmtPaid,
			decimal? PAmtDisc,
			string PApStr,
			int? PBadVouch,
			int? PBadAp,
			int? PBadDisc,
			string Infobar);
	}
}

