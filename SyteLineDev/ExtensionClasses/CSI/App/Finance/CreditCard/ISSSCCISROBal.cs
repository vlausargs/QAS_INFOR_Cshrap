//PROJECT NAME: Finance
//CLASS NAME: ISSSCCISROBal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
	public interface ISSSCCISROBal
	{
		(int? ReturnCode, decimal? Balance,
		decimal? TaxAmt,
		decimal? ExchRate,
		decimal? ForAmt,
		int? CustSeq,
		string Infobar) SSSCCISROBalSp(string SroNum,
		decimal? Balance,
		decimal? TaxAmt,
		decimal? ExchRate,
		decimal? ForAmt,
		int? CustSeq,
		string Infobar);
	}
}

