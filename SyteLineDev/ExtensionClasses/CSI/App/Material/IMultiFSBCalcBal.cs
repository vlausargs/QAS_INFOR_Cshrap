//PROJECT NAME: Finance
//CLASS NAME: IMultiFSBCalcBal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMultiFSBCalcBal
	{
		(int? ReturnCode,
			decimal? Balance,
			string Infobar) MultiFSBCalcBalSp(
			string TMethod,
			int? TUse,
			DateTime? SDate,
			DateTime? EDate,
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
			decimal? Balance,
			string Infobar,
			string pSite = null,
			string PeriodName = null,
			string FSBName = null);
	}
}

