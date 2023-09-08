//PROJECT NAME: Data
//CLASS NAME: IPortalSendNotificationEmails.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPortalSendNotificationEmails
	{
		(int? ReturnCode,
			string Infobar) PortalSendNotificationEmailsSp(
			string UserName,
			string Subject,
			string Category = null,
			string Body = null,
			string HTMLBody = null,
			string Infobar = null,
			string AlertEventName = null,
			string SentEmailAlertTo = null,
			string AlertVarName5 = null,
			string AlertVarValue5 = null,
			string AlertVarName6 = null,
			string AlertVarValue6 = null,
			string AlertVarName7 = null,
			string AlertVarValue7 = null,
			string AlertVarName8 = null,
			string AlertVarValue8 = null,
			string AlertVarName9 = null,
			string AlertVarValue9 = null,
			string AlertVarName10 = null,
			string AlertVarValue10 = null,
			string AlertVarName11 = null,
			string AlertVarValue11 = null,
			string AlertVarName12 = null,
			string AlertVarValue12 = null,
			string AlertVarName13 = null,
			string AlertVarValue13 = null,
			string AlertVarName14 = null,
			string AlertVarValue14 = null,
			string AlertVarName15 = null,
			string AlertVarValue15 = null,
			string AlertVarName16 = null,
			string AlertVarValue16 = null,
			string AlertVarName17 = null,
			string AlertVarValue17 = null,
			string AlertVarName18 = null,
			string AlertVarValue18 = null,
			string AlertVarName19 = null,
			string AlertVarValue19 = null,
			string AlertVarName20 = null,
			string AlertVarValue20 = null);
	}
}

