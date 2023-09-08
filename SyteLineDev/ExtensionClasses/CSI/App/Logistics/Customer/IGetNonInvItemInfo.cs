//PROJECT NAME: Logistics
//CLASS NAME: IGetNonInvItemInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetNonInvItemInfo
	{
		(int? ReturnCode, string Description,
		string UM,
		string MatlType,
		string Revision,
		string ProductCode,
		string DrawingNum,
		string FamilyCode,
		string Buyer,
		string CommCode,
		string Origin,
		int? SubjectToNaftaRvc,
		decimal? UnitCost,
		string PrefCrit,
		int? Producer,
		string WeightUnit,
		decimal? UnitWeight,
		decimal? UnitPrice,
		int? AllowOnPickList,
		string Infobar) GetNonInvItemInfoSp(string Item,
		string Description = null,
		string UM = null,
		string MatlType = null,
		string Revision = null,
		string ProductCode = null,
		string DrawingNum = null,
		string FamilyCode = null,
		string Buyer = null,
		string CommCode = null,
		string Origin = null,
		int? SubjectToNaftaRvc = null,
		decimal? UnitCost = 0,
		string PrefCrit = null,
		int? Producer = null,
		string WeightUnit = null,
		decimal? UnitWeight = 0,
		decimal? UnitPrice = 0,
		int? AllowOnPickList = null,
		string Infobar = null,
		string CurrCode = null,
		string OrderType = null,
		string OrderKey1 = null);
	}
}

