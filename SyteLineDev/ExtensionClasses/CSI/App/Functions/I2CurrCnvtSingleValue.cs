//PROJECT NAME: Data
//CLASS NAME: I2CurrCnvtSingleValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface I2CurrCnvtSingleValue
	{
		(int? ReturnCode,
			decimal? TRate,
			string Infobar,
			decimal? Result) TwoCurrCnvtSingleValueSp(
			string ToCurrCode,
			int? UseBuyRate,
			int? RoundResult,
			DateTime? RateDate = null,
			int? RoundPlaces = null,
			string BRateTable = "currate",
			int? ForceRate = null,
			int? FindTTFixed = null,
			string FromCurrCode = null,
			decimal? TRate = null,
			string Infobar = null,
			decimal? Amount = null,
			decimal? Result = null,
			string Site = null);
	}
}

