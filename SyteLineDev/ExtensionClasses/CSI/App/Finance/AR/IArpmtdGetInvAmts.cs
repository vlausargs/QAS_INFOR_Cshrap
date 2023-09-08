//PROJECT NAME: Finance
//CLASS NAME: IArpmtdGetInvAmts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmtdGetInvAmts
	{
		(int? ReturnCode,
			decimal? PArpmtdForAmtApplied,
			decimal? PArpmtdForDiscAmt,
			decimal? PArpmtdDomAmtApplied,
			decimal? PArpmtdDomDiscAmt,
			decimal? PArpmtdExchRate,
			string Infobar) ArpmtdGetInvAmtsSp(
			string PArpmtdSite,
			string PArpmtdApplyCustNum,
			string PArpmtdInvNum,
			DateTime? PArpmtRecptDate,
			string PDerCustCurrCode,
			decimal? PForAmtRem,
			decimal? PArpmtdForAmtApplied,
			decimal? PArpmtdForDiscAmt,
			decimal? PArpmtdDomAmtApplied,
			decimal? PArpmtdDomDiscAmt,
			decimal? PArpmtdExchRate,
			string Infobar);
	}
}

