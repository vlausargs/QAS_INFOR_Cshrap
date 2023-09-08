//PROJECT NAME: Finance
//CLASS NAME: IJournalCalcDomAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IJournalCalcDomAmt
	{
		(int? ReturnCode, decimal? PDomAmtDr,
		decimal? PDomAmtCr,
		decimal? PExchRate,
		string Infobar) JournalCalcDomAmtSp(int? PRecalcFor,
		decimal? PDomAmtDr,
		decimal? PDomAmtCr,
		string PCurrCode,
		decimal? PForAmtDr,
		decimal? PForAmtCr,
		decimal? PExchRate,
		string Infobar);
	}
}

