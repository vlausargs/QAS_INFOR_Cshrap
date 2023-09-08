//PROJECT NAME: Logistics
//CLASS NAME: IBlanketReleaseLineValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IBlanketReleaseLineValid
	{
		(int? ReturnCode, string CblItem,
		decimal? CblBlanketQtyConv,
		decimal? CblContPriceConv,
		string CblUM,
		DateTime? CblEffDate,
		DateTime? CblExpDate,
		int? CoEdiOrder,
		int? ItemPlanFlag,
		string CoWhse,
		string CoSite,
		int? ICDuePeriod,
		int? ItemDuePeriod,
		string Infobar) BlanketReleaseLineValidSp(string CoNum,
		int? CoLine,
		string CblItem,
		decimal? CblBlanketQtyConv,
		decimal? CblContPriceConv,
		string CblUM,
		DateTime? CblEffDate,
		DateTime? CblExpDate,
		int? CoEdiOrder,
		int? ItemPlanFlag,
		string CoWhse,
		string CoSite,
		int? ICDuePeriod,
		int? ItemDuePeriod,
		string Infobar);
	}
}

