//PROJECT NAME: Data
//CLASS NAME: GetSendEmailNotificationsFlag.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetSendEmailNotificationsFlag : IGetSendEmailNotificationsFlag
	{
		readonly IApplicationDB appDB;
		
		public GetSendEmailNotificationsFlag(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			int? SendEmailNotifications,
			int? UsePortalEmail,
			string SentEmailAlertTo) GetSendEmailNotificationsFlagSp(
			string UserName = null,
			string Infobar = null,
			int? SendEmailNotifications = null,
			int? UsePortalEmail = null,
			string SentEmailAlertTo = null)
		{
			UsernameType _UserName = UserName;
			InfobarType _Infobar = Infobar;
			ListYesNoType _SendEmailNotifications = SendEmailNotifications;
			ListYesNoType _UsePortalEmail = UsePortalEmail;
			EventVariableValueType _SentEmailAlertTo = SentEmailAlertTo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetSendEmailNotificationsFlagSp";
				
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SendEmailNotifications", _SendEmailNotifications, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UsePortalEmail", _UsePortalEmail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SentEmailAlertTo", _SentEmailAlertTo, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				SendEmailNotifications = _SendEmailNotifications;
				UsePortalEmail = _UsePortalEmail;
				SentEmailAlertTo = _SentEmailAlertTo;
				
				return (Severity, Infobar, SendEmailNotifications, UsePortalEmail, SentEmailAlertTo);
			}
		}
	}
}
