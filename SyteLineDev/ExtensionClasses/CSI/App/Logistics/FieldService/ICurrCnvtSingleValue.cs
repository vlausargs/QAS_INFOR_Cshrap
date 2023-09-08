//PROJECT NAME: Logistics
//CLASS NAME: ICurrCnvtSingleValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ICurrCnvtSingleValue
	{
		(int? ReturnCode, decimal? TRate,
		string Infobar,
		decimal? Result) CurrCnvtSingleValueSp(string CurrCode,
		int? FromDomestic,
		int? UseBuyRate,
		int? RoundResult,
		DateTime? RateDate = null,
		int? RoundPlaces = null,
		string BRateTable = "currate",
		int? ForceRate = null,
		int? FindTTFixed = null,
		decimal? TRate = null,
		string Infobar = null,
		decimal? Amount = null,
		decimal? Result = null,
		string Site = null);
	}
}

