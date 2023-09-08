//PROJECT NAME: Finance
//CLASS NAME: ICalcBalSprateCrDr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICalcBalSprateCrDr
	{
		(int? ReturnCode,
			decimal? Balance,
			string Infobar) CalcBalSprateCrDrSp(
			string TMethod,
			int? TUse,
			DateTime? SDate,
			DateTime? EDate,
			string PHierarchy,
			string PAcct,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			string PSort,
			string PType,
			int? PIncome,
			string PBalType,
			string PCurrCode,
			int? PSortMethod,
			int? SeparateDrCrAmounts = 0,
			decimal? Balance = null,
			string Infobar = null,
			string pSite = null,
			DateTime? Today = null,
			DateTime? FirstPeriodPerStart = null,
			DateTime? LastPeriodPerEnd = null);
	}
}

