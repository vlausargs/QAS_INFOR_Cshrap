//PROJECT NAME: Data
//CLASS NAME: IEuroCustCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEuroCustCo
	{
		int? EuroCustCoSp(
			string pUpdateOrderType,
			string pCusNum,
			string pFromCurrencyCode,
			string pToEuroCurrencyCode,
			int? pToCurrencyPlaces,
			int? pIsFixed,
			decimal? pResultantRate,
			decimal? pDomToEuro,
			decimal? pForToEuro);
	}
}

