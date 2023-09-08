//PROJECT NAME: Codes
//CLASS NAME: IPortalAccountCreateOrCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IPortalAccountCreateOrCopy
	{
		(int? ReturnCode, string Infobar) PortalAccountCreateOrCopySp(string Username,
		string CustVendNum,
		string Name,
		string Email,
		string NotificationEmail,
		string EmailType,
		string EmailTypeDesc,
		string Password,
		string AccountType,
		string Slsman,
		string VendNum,
		int? SendEmailNotifications,
		string EmailNotificationsEmailType,
		string EmailNotificationsEmailTypeDesc,
		string PrimarySite,
		int? Create,
		decimal? ResellerCommission,
		int? LocaleId,
		string Infobar);
	}
}

