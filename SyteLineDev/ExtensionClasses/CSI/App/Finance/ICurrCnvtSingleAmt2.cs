//PROJECT NAME: Data
//CLASS NAME: ICurrCnvtSingleAmt2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICurrCnvtSingleAmt2
	{
		decimal? CurrCnvtSingleAmt2Fn(string CurrCode,
		int? FromDomestic,
		int? UseBuyRate,
		int? RoundResult,
		DateTime? Date,
		int? RoundPlaces,
		int? UseCustomsAndExciseRates,
		int? ForceRate,
		decimal? TRate,
		string Site,
		string DomCurrCode,
		int? TRateD,
		decimal? Amount1);
	}
}

