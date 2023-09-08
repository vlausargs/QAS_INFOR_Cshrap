//PROJECT NAME: Finance
//CLASS NAME: ICalcBalSetVars.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICalcBalSetVars
	{
		(int? ReturnCode,
			decimal? Balance,
			DateTime? SLedger,
			DateTime? ELedger,
			int? FirstTimeRun,
			string Infobar) CalcBalSetVarsSp(
			string TMethod,
			int? TUse,
			int? TTrans,
			string PCurrCode,
			int? PIncome,
			DateTime? PertotPerStart,
			DateTime? PertotPerEnd,
			decimal? PertotAmt,
			decimal? PertotSummary,
			decimal? Balance,
			DateTime? SLedger,
			DateTime? ELedger,
			int? FirstTimeRun,
			string Infobar,
			string pSite = null);
	}
}

