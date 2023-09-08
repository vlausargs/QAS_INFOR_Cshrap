//PROJECT NAME: Codes
//CLASS NAME: IJournalCalcExchRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IJournalCalcExchRate
	{
		(int? ReturnCode, decimal? PRate,
		string Infobar) JournalCalcExchRateSp(string PCurrCode,
		decimal? PForAmt,
		decimal? PDomAmt,
		decimal? PRate,
		string Infobar);
	}
}

