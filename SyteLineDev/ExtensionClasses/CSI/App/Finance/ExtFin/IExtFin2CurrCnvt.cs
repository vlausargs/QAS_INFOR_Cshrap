//PROJECT NAME: Finance
//CLASS NAME: IExtFin2CurrCnvt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFin2CurrCnvt
	{
		(int? ReturnCode,
			decimal? TRate,
			string Infobar,
			int? TRateD,
			decimal? Result1,
			decimal? Result2,
			decimal? Result3,
			decimal? Result4,
			decimal? Result5,
			decimal? Result6,
			decimal? Result7,
			decimal? Result8,
			decimal? Result9,
			decimal? Result10,
			decimal? Result11,
			decimal? Result12,
			decimal? Result13,
			decimal? Result14,
			decimal? Result15) ExtFin2CurrCnvtSp(
			string ToCurrCode,
			int? UseBuyRate,
			int? RoundResult,
			DateTime? Date = null,
			int? RoundPlaces = null,
			int? UseCustomsAndExciseRates = 0,
			int? ForceRate = null,
			int? FindTTFixed = null,
			decimal? TRate = null,
			string Infobar = null,
			string Site = null,
			string FromCurrCode = null,
			int? TRateD = null,
			decimal? Amount1 = null,
			decimal? Result1 = null,
			decimal? Amount2 = null,
			decimal? Result2 = null,
			decimal? Amount3 = null,
			decimal? Result3 = null,
			decimal? Amount4 = null,
			decimal? Result4 = null,
			decimal? Amount5 = null,
			decimal? Result5 = null,
			decimal? Amount6 = null,
			decimal? Result6 = null,
			decimal? Amount7 = null,
			decimal? Result7 = null,
			decimal? Amount8 = null,
			decimal? Result8 = null,
			decimal? Amount9 = null,
			decimal? Result9 = null,
			decimal? Amount10 = null,
			decimal? Result10 = null,
			decimal? Amount11 = null,
			decimal? Result11 = null,
			decimal? Amount12 = null,
			decimal? Result12 = null,
			decimal? Amount13 = null,
			decimal? Result13 = null,
			decimal? Amount14 = null,
			decimal? Result14 = null,
			decimal? Amount15 = null,
			decimal? Result15 = null);
	}
}

