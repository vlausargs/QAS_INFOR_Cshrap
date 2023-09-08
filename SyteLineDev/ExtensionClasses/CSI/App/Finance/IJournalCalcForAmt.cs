//PROJECT NAME: Finance
//CLASS NAME: IJournalCalcForAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IJournalCalcForAmt
	{
		(int? ReturnCode, decimal? PForAmtDr,
		decimal? PForAmtCr,
		decimal? PExchRate,
		string Infobar) JournalCalcForAmtSp(int? PRecalcFor,
		decimal? PDomAmtDr,
		decimal? PDomAmtCr,
		string PCurrCode,
		decimal? PForAmtDr,
		decimal? PForAmtCr,
		decimal? PExchRate,
		string Infobar);
	}
}

