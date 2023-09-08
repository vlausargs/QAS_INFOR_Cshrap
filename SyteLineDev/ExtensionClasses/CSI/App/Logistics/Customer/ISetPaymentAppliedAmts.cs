//PROJECT NAME: Logistics
//CLASS NAME: ISetPaymentAppliedAmts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISetPaymentAppliedAmts
	{
		(int? ReturnCode, decimal? PToApplied,
		decimal? PExchRate,
		decimal? PToRemaining,
		string Infobar) SetPaymentAppliedAmtsSp(string PFromCurrCode,
		string PToCurrCode,
		decimal? PToApplied,
		DateTime? PRecptDate,
		decimal? PExchRate,
		decimal? PFromApplied,
		decimal? PToCheckAmt,
		decimal? PToRemaining,
		decimal? PDomRemaning,
		string Infobar);
	}
}

