//PROJECT NAME: BusInterface
//CLASS NAME: ICalcLineTaxBasisAmount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICalcLineTaxBasisAmount
	{
		decimal? CalcLineTaxBasisAmountFn(
			decimal? ExtPrice,
			decimal? DiscAmount,
			int? RoundResult,
			int? DecimalPlaces = null);
	}
}

