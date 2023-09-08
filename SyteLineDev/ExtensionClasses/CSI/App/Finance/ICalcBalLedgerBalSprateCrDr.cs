//PROJECT NAME: Finance
//CLASS NAME: ICalcBalLedgerBalSprateCrDr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICalcBalLedgerBalSprateCrDr
	{
		(int? ReturnCode,
			decimal? Balance,
			string Infobar) CalcBalLedgerBalSprateCrDrSp(
			int? TAnalytical,
			string TMethod,
			int? TUse,
			DateTime? PStartDate,
			DateTime? PEndDate,
			string PHierarchy,
			string PAcct,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			string PType,
			string PBalType,
			int? THasGoodPerSort,
			int? UseU1,
			int? UseU2,
			int? UseU3,
			int? UseU4,
			int? TTrans,
			string PCurrCode,
			int? PIncome,
			int? SeparateDrCrAmounts = 0,
			decimal? Balance = null,
			string Infobar = null,
			string pSite = null);
	}
}

