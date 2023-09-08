//PROJECT NAME: Finance
//CLASS NAME: IAp04RI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AP
{
	public interface IAp04RI
	{
		(int? ReturnCode,
			decimal? TcAmtDisplay,
			decimal? TcAmtTotDr,
			decimal? TcAmtTotCr,
			decimal? DomTcAmtTotDr,
			decimal? DomTcAmtTotCr,
			decimal? DomTcAmtDisplay,
			string AcctTxt,
			string InfoBar) Ap04RISP(
			int? PGainLoss,
			string VendorCurrCode,
			string CurrparmsCurrCode,
			decimal? PExchRate,
			decimal? PInvAmt,
			string PAcct,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			decimal? TcAmtDisplay,
			decimal? TcAmtTotDr,
			decimal? TcAmtTotCr,
			decimal? DomTcAmtTotDr,
			decimal? DomTcAmtTotCr,
			decimal? DomTcAmtDisplay,
			string AcctTxt,
			string InfoBar,
			int? PCancellation = 0);
	}
}

