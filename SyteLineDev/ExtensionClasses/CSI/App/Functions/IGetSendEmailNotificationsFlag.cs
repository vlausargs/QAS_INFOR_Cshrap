//PROJECT NAME: Data
//CLASS NAME: IGetSendEmailNotificationsFlag.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetSendEmailNotificationsFlag
	{
		(int? ReturnCode,
			string Infobar,
			int? SendEmailNotifications,
			int? UsePortalEmail,
			string SentEmailAlertTo) GetSendEmailNotificationsFlagSp(
			string UserName = null,
			string Infobar = null,
			int? SendEmailNotifications = null,
			int? UsePortalEmail = null,
			string SentEmailAlertTo = null);
	}
}

