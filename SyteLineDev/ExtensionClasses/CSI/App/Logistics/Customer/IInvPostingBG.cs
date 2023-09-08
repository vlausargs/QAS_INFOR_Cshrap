//PROJECT NAME: Logistics
//CLASS NAME: IInvPostingBG.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IInvPostingBG
	{
		int? InvPostingBGSp(string StartingCustNum = null,
		string EndingCustNum = null,
		string InvNumStarting = null,
		string InvNumEnding = null,
		DateTime? InvoiceDateStarting = null,
		DateTime? InvoiceDateEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		string InvoiceFlag = null,
		string DebitMemoFlag = null,
		string CreditMemoFlag = null,
		int? DisplayTotals = null,
		int? SortBy = null,
		int? DisplayHeader = null,
		int? SeparateDrCrAmounts = null,
		string SessionIDChar = null,
		string ToSite = null,
		string StartBuilderInvNum = null,
		string EndBuilderInvNum = null,
		string PSite = null,
		decimal? UserId = null);
	}
}

