//PROJECT NAME: Finance
//CLASS NAME: IArpmtdGetExchRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmtdGetExchRate
	{
		(int? ReturnCode,
			decimal? PRate,
			int? PUpdateRate) ArpmtdGetExchRateSp(
			string PArpmtdSite,
			int? PAddMode,
			string PArpmtdType,
			decimal? PArpmtdExchRate,
			decimal? PArpmtExchRate,
			string PArpmtCustNum,
			string PArpmtdInvNum,
			decimal? PRate,
			int? PUpdateRate,
			string PCustCurrCode = null,
			string PArpmtBankCode = null,
			string PArpmtPaymentCurrCode = null,
			decimal? PArpmtPaymentExchRate = null);
	}
}

