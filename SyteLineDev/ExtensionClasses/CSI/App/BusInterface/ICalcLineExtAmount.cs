//PROJECT NAME: BusInterface
//CLASS NAME: ICalcLineExtAmount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICalcLineExtAmount
	{
		decimal? CalcLineExtAmountFn(
			decimal? Price,
			decimal? Qty,
			int? RoundResult,
			int? DecimalPlaces = null,
			string ForCurrCode = null,
			DateTime? TransDate = null,
			string ISOCountryCode = null,
			decimal? ForExchangeRate = null,
			int? ReportCurrency = 0);
	}
}

