//PROJECT NAME: Reporting
//CLASS NAME: ICHSRpt_DebitCreditAssign.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ICHSRpt_DebitCreditAssign
	{
		(int? ReturnCode,
			decimal? DebitValue,
			decimal? CreditValue,
			decimal? FDebitValue,
			decimal? FCreditValue,
			decimal? BalanceValue,
			decimal? FBalanceValue,
			string InfoBar) CHSRpt_DebitCreditAssignSp(
			int? AcctStatus,
			decimal? DomAmount,
			decimal? ForAmount,
			int? Rubric,
			decimal? DebitValue,
			decimal? CreditValue,
			decimal? FDebitValue,
			decimal? FCreditValue,
			decimal? BalanceValue,
			decimal? FBalanceValue,
			string InfoBar);
	}
}

