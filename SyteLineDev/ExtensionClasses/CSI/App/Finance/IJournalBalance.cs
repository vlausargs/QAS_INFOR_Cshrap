//PROJECT NAME: Finance
//CLASS NAME: IJournalBalance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IJournalBalance
	{
		(int? ReturnCode, decimal? BalDr,
		decimal? BalCr,
		decimal? RevDr,
		decimal? RevCr,
		string Infobar) JournalBalanceSp(string JournalId,
		decimal? BalDr,
		decimal? BalCr,
		decimal? RevDr,
		decimal? RevCr,
		string GLVouchers = null,
		string Infobar = null);
	}
}

