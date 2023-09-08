//PROJECT NAME: Finance
//CLASS NAME: IArpmtdGetNewExchRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmtdGetNewExchRate
	{
		(int? ReturnCode,
			decimal? PRate,
			string Infobar) ArpmtdGetNewExchRateSp(
			string PDerCustCurrCode,
			decimal? PForAmt,
			decimal? PDomAmt,
			decimal? PRate,
			string Infobar);
	}
}

