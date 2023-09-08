//PROJECT NAME: Finance
//CLASS NAME: ICalcActualBal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICalcActualBal
	{
		(int? ReturnCode,
			decimal? Balance1,
			decimal? Balance2,
			decimal? Balance3,
			decimal? Balance4,
			decimal? Balance5,
			decimal? Balance6,
			decimal? Balance7,
			decimal? Balance8,
			decimal? Balance9,
			decimal? Balance10,
			decimal? Balance11,
			decimal? Balance12,
			decimal? Balance13,
			string Infobar) CalcActualBalSp(
			int? PFiscalYear,
			string PAcct,
			string PType,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			string PHierarchy,
			string PCurrCode,
			decimal? Balance1,
			decimal? Balance2,
			decimal? Balance3,
			decimal? Balance4,
			decimal? Balance5,
			decimal? Balance6,
			decimal? Balance7,
			decimal? Balance8,
			decimal? Balance9,
			decimal? Balance10,
			decimal? Balance11,
			decimal? Balance12,
			decimal? Balance13,
			string Infobar);
	}
}

