//PROJECT NAME: BusInterface
//CLASS NAME: ICalcLineDiscAmount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICalcLineDiscAmount
	{
		decimal? CalcLineDiscAmountFn(
			decimal? ExtPrice,
			decimal? DiscRate,
			int? RoundResult,
			int? DecimalPlaces = null);
	}
}

