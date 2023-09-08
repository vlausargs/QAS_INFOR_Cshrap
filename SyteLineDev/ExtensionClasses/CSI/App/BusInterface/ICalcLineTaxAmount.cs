//PROJECT NAME: BusInterface
//CLASS NAME: ICalcLineTaxAmount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICalcLineTaxAmount
	{
		decimal? CalcLineTaxAmountFn(
			decimal? TaxBasisAmount,
			decimal? TaxRate,
			int? RoundResult,
			int? DecimalPlaces = null);
	}
}

