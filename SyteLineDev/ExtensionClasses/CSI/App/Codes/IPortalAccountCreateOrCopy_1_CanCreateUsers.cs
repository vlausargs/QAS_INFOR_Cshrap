//PROJECT NAME: Codes
//CLASS NAME: IPortalAccountCreateOrCopy_1_CanCreateUsers.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IPortalAccountCreateOrCopy_1_CanCreateUsers
	{
		(int? ReturnCode, string Infobar) PortalAccountCreateOrCopy_1_CanCreateUsersSp(string Username,
		string CustVendNum,
		string Name,
		string Email,
		string NotificationEmail,
		string EmailType,
		string EmailTypeDesc,
		string Password,
		string AccountType,
		string VendNum,
		int? SendEmailNotifications,
		string EmailNotificationsEmailType,
		string EmailNotificationsEmailTypeDesc,
		string PrimarySite,
		int? Create,
		int? LocaleId,
		string Infobar,
		int? CanCreateUsers,
		int? PreCanCreateUsers);
	}
}

