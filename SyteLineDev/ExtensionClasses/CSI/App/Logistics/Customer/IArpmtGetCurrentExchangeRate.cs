//PROJECT NAME: Logistics
//CLASS NAME: IArpmtGetCurrentExchangeRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IArpmtGetCurrentExchangeRate
	{
		(int? ReturnCode, decimal? PExchRate,
		string PInfobar) ArpmtGetCurrentExchangeRateSp(string PBankCurrCode,
		DateTime? PRecptDate,
		decimal? PExchRate,
		string PInfobar);
	}
}

