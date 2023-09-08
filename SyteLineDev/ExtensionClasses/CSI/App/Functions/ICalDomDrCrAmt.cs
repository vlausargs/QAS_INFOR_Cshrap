//PROJECT NAME: Data
//CLASS NAME: ICalDomDrCrAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICalDomDrCrAmt
	{
		(int? ReturnCode,
			decimal? TcAmtDisplay,
			decimal? DomTcAmtTotDr,
			decimal? DomTcAmtTotCr,
			decimal? DomTcAmtDisplay,
			string AcctTxt,
			string InfoBar,
			decimal? TcAmtTotDr,
			decimal? TcAmtTotCr) CalDomDrCrAmtSp(
			int? PGainLoss,
			string AptrxCurrCode,
			string CurrparmsCurrCode,
			decimal? PExchRate,
			decimal? PInvAmt,
			string PAcct,
			decimal? TcAmtDisplay,
			decimal? DomTcAmtTotDr,
			decimal? DomTcAmtTotCr,
			decimal? DomTcAmtDisplay,
			string AcctTxt,
			string InfoBar,
			decimal? TcAmtTotDr,
			decimal? TcAmtTotCr,
			int? InsTemp = 0,
			string PAcctUnit1 = null,
			string PAcctUnit2 = null,
			string PAcctUnit3 = null,
			string PAcctUnit4 = null);
	}
}

