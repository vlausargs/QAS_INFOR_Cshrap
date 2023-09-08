//PROJECT NAME: Finance
//CLASS NAME: ICurrCnvtSingleAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICurrCnvtSingleAmt
	{
		ICollectionLoadResponse CurrCnvtSingleAmtFn(
			string CurrCode,
			int? FromDomestic,
			int? UseBuyRate,
			int? RoundResult,
			DateTime? Date = null,
			int? RoundPlaces = null,
			int? UseCustomsAndExciseRates = 0,
			int? ForceRate = null,
			decimal? TRate = null,
			string Site = null,
			string DomCurrCode = null,
			int? TRateD = null,
			decimal? Amount1 = null);
	}
}

