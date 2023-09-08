//PROJECT NAME: Data
//CLASS NAME: IEuroCustAdjustRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEuroCustAdjustRate
	{
		decimal? EuroCustAdjustRateFn(
			decimal? pAmount,
			int? pIsFixed,
			decimal? pResultantRate,
			decimal? pDomToEuro,
			decimal? pForToEuro);
	}
}

