//PROJECT NAME: Logistics
//CLASS NAME: IApVchPostingBG.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IApVchPostingBG
	{
		int? ApVchPostingBGSp(string StartingVendNum = null,
		string EndingVendNum = null,
		int? VoucherStarting = null,
		int? VoucherEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		DateTime? DisDateStarting = null,
		DateTime? DisDateEnding = null,
		string AuthorizationStatus = null,
		string SortBy = null,
		int? DisplayTotals = null,
		int? DisplayHeader = null,
		int? SeparateDrCrAmounts = null,
		string SessionIDChar = null,
		string pSite = null,
		decimal? UserId = null);
	}
}

