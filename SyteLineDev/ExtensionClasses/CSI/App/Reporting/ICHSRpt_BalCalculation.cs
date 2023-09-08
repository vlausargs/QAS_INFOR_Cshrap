//PROJECT NAME: Reporting
//CLASS NAME: ICHSRpt_BalCalculation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ICHSRpt_BalCalculation
	{
		(int? ReturnCode,
			decimal? DDebitAmount,
			decimal? FDebitAmount,
			decimal? DCreditAmount,
			decimal? FCreditAmount,
			decimal? DebitCredit,
			decimal? BalAmount,
			decimal? DBalAmount,
			decimal? FBalAmount,
			decimal? DPrevYearBalance,
			decimal? FPrevYearBalance,
			decimal? ExRate,
			string InfoBar) CHSRpt_BalCalculationSp(
			string Acct,
			int? SortMethod,
			string CurrCode,
			int? FrgnCurr,
			DateTime? StartPeriod,
			DateTime? ENDDate,
			DateTime? BeginDate,
			string Unit1,
			string Unit2,
			string Unit3,
			string Unit4,
			string TempType,
			decimal? DDebitAmount,
			decimal? FDebitAmount,
			decimal? DCreditAmount,
			decimal? FCreditAmount,
			decimal? DebitCredit,
			decimal? BalAmount,
			decimal? DBalAmount,
			decimal? FBalAmount,
			decimal? DPrevYearBalance,
			decimal? FPrevYearBalance,
			decimal? ExRate,
			string InfoBar);
	}
}

