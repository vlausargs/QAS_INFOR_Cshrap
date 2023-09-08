//PROJECT NAME: Finance
//CLASS NAME: IExcelGetPeriodAvgEndRatesForYear.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IExcelGetPeriodAvgEndRatesForYear
	{
		(int? ReturnCode, decimal? PAvgRate01,
		decimal? PEndRate01,
		decimal? PAvgRate02,
		decimal? PEndRate02,
		decimal? PAvgRate03,
		decimal? PEndRate03,
		decimal? PAvgRate04,
		decimal? PEndRate04,
		decimal? PAvgRate05,
		decimal? PEndRate05,
		decimal? PAvgRate06,
		decimal? PEndRate06,
		decimal? PAvgRate07,
		decimal? PEndRate07,
		decimal? PAvgRate08,
		decimal? PEndRate08,
		decimal? PAvgRate09,
		decimal? PEndRate09,
		decimal? PAvgRate10,
		decimal? PEndRate10,
		decimal? PAvgRate11,
		decimal? PEndRate11,
		decimal? PAvgRate12,
		decimal? PEndRate12,
		decimal? PAvgRate13,
		decimal? PEndRate13,
		decimal? PCurrentRate,
		string Infobar) ExcelGetPeriodAvgEndRatesForYearSp(string PSite = null,
		string PFromCurrCode = null,
		string PToCurrCode = null,
		int? PUseBuyRate = 1,
		int? PFiscalYear = null,
		decimal? PAvgRate01 = null,
		decimal? PEndRate01 = null,
		decimal? PAvgRate02 = null,
		decimal? PEndRate02 = null,
		decimal? PAvgRate03 = null,
		decimal? PEndRate03 = null,
		decimal? PAvgRate04 = null,
		decimal? PEndRate04 = null,
		decimal? PAvgRate05 = null,
		decimal? PEndRate05 = null,
		decimal? PAvgRate06 = null,
		decimal? PEndRate06 = null,
		decimal? PAvgRate07 = null,
		decimal? PEndRate07 = null,
		decimal? PAvgRate08 = null,
		decimal? PEndRate08 = null,
		decimal? PAvgRate09 = null,
		decimal? PEndRate09 = null,
		decimal? PAvgRate10 = null,
		decimal? PEndRate10 = null,
		decimal? PAvgRate11 = null,
		decimal? PEndRate11 = null,
		decimal? PAvgRate12 = null,
		decimal? PEndRate12 = null,
		decimal? PAvgRate13 = null,
		decimal? PEndRate13 = null,
		decimal? PCurrentRate = null,
		string Infobar = null);
	}
}

