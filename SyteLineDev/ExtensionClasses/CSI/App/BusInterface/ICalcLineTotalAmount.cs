//PROJECT NAME: BusInterface
//CLASS NAME: ICalcLineTotalAmount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICalcLineTotalAmount
	{
		decimal? CalcLineTotalAmountFn(
			decimal? ExtPrice,
			decimal? DiscAmount,
			decimal? TaxAmount,
			int? RoundResult,
			int? DecimalPlaces = null,
			decimal? WithholdingTax = null);
	}
}

