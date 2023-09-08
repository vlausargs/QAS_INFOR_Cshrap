//PROJECT NAME: Data
//CLASS NAME: IEuroCustAdjustAmount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEuroCustAdjustAmount
	{
		decimal? EuroCustAdjustAmountFn(
			decimal? pAmount,
			int? pRound,
			decimal? pForToEuro,
			int? pCurrencyPlaces);
	}
}

