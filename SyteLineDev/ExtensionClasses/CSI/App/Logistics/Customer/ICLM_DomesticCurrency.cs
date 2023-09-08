//PROJECT NAME: Logistics
//CLASS NAME: ICLM_DomesticCurrency.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_DomesticCurrency
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_DomesticCurrencySp(string CurrCode,
		int? UseBuyRate = 0,
		decimal? TRate = null,
		DateTime? PossibleDate = null,
		decimal? Amount1 = null,
		decimal? Amount2 = null,
		decimal? Amount3 = null,
		decimal? Amount4 = null,
		decimal? Amount5 = null,
		decimal? Amount6 = null,
		decimal? Amount7 = null,
		decimal? Amount8 = null,
		decimal? Amount9 = null,
		decimal? Amount10 = null,
		decimal? Amount11 = null,
		decimal? Amount12 = null,
		decimal? Amount13 = null,
		decimal? Amount14 = null,
		decimal? Amount15 = null,
		decimal? Amount16 = null,
		decimal? Amount17 = null,
		decimal? Amount18 = null,
		decimal? Amount19 = null,
		decimal? Amount20 = null,
		decimal? Amount21 = null,
		decimal? Amount22 = null,
		decimal? Amount23 = null,
		decimal? Amount24 = null,
		decimal? Amount25 = null,
		decimal? Amount26 = null,
		decimal? Amount27 = null,
		decimal? Amount28 = null,
		decimal? Amount29 = null,
		decimal? Amount30 = null,
		decimal? Amount31 = null,
		decimal? Amount32 = null,
		decimal? Amount33 = null,
		decimal? Amount34 = null,
		decimal? Amount35 = null,
		decimal? Amount36 = null,
		decimal? Amount37 = null,
		decimal? Amount38 = null,
		decimal? Amount39 = null,
		decimal? Amount40 = null);
	}
}

