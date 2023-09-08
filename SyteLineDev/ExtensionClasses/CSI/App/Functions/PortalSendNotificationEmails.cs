//PROJECT NAME: Data
//CLASS NAME: PortalSendNotificationEmails.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PortalSendNotificationEmails : IPortalSendNotificationEmails
	{
		readonly IApplicationDB appDB;
		
		public PortalSendNotificationEmails(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string AlertVarValue20 = null)
		{
			UsernameType _UserName = UserName;
			MessageSubjectType _Subject = Subject;
			MessageCategoryType _Category = Category;
			NoteType _Body = Body;
			NoteType _HTMLBody = HTMLBody;
			InfobarType _Infobar = Infobar;
			InfobarType _AlertEventName = AlertEventName;
			EventVariableValueType _SentEmailAlertTo = SentEmailAlertTo;
			EventVariableNameType _AlertVarName5 = AlertVarName5;
			EventVariableValueType _AlertVarValue5 = AlertVarValue5;
			EventVariableNameType _AlertVarName6 = AlertVarName6;
			EventVariableValueType _AlertVarValue6 = AlertVarValue6;
			EventVariableNameType _AlertVarName7 = AlertVarName7;
			EventVariableValueType _AlertVarValue7 = AlertVarValue7;
			EventVariableNameType _AlertVarName8 = AlertVarName8;
			EventVariableValueType _AlertVarValue8 = AlertVarValue8;
			EventVariableNameType _AlertVarName9 = AlertVarName9;
			EventVariableValueType _AlertVarValue9 = AlertVarValue9;
			EventVariableNameType _AlertVarName10 = AlertVarName10;
			EventVariableValueType _AlertVarValue10 = AlertVarValue10;
			EventVariableNameType _AlertVarName11 = AlertVarName11;
			EventVariableValueType _AlertVarValue11 = AlertVarValue11;
			EventVariableNameType _AlertVarName12 = AlertVarName12;
			EventVariableValueType _AlertVarValue12 = AlertVarValue12;
			EventVariableNameType _AlertVarName13 = AlertVarName13;
			EventVariableValueType _AlertVarValue13 = AlertVarValue13;
			EventVariableNameType _AlertVarName14 = AlertVarName14;
			EventVariableValueType _AlertVarValue14 = AlertVarValue14;
			EventVariableNameType _AlertVarName15 = AlertVarName15;
			EventVariableValueType _AlertVarValue15 = AlertVarValue15;
			EventVariableNameType _AlertVarName16 = AlertVarName16;
			EventVariableValueType _AlertVarValue16 = AlertVarValue16;
			EventVariableNameType _AlertVarName17 = AlertVarName17;
			EventVariableValueType _AlertVarValue17 = AlertVarValue17;
			EventVariableNameType _AlertVarName18 = AlertVarName18;
			EventVariableValueType _AlertVarValue18 = AlertVarValue18;
			EventVariableNameType _AlertVarName19 = AlertVarName19;
			EventVariableValueType _AlertVarValue19 = AlertVarValue19;
			EventVariableNameType _AlertVarName20 = AlertVarName20;
			EventVariableValueType _AlertVarValue20 = AlertVarValue20;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalSendNotificationEmailsSp";
				
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Subject", _Subject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Category", _Category, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Body", _Body, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HTMLBody", _HTMLBody, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AlertEventName", _AlertEventName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SentEmailAlertTo", _SentEmailAlertTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarName5", _AlertVarName5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarValue5", _AlertVarValue5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarName6", _AlertVarName6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarValue6", _AlertVarValue6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarName7", _AlertVarName7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarValue7", _AlertVarValue7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarName8", _AlertVarName8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarValue8", _AlertVarValue8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarName9", _AlertVarName9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarValue9", _AlertVarValue9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarName10", _AlertVarName10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarValue10", _AlertVarValue10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarName11", _AlertVarName11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarValue11", _AlertVarValue11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarName12", _AlertVarName12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarValue12", _AlertVarValue12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarName13", _AlertVarName13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarValue13", _AlertVarValue13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarName14", _AlertVarName14, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarValue14", _AlertVarValue14, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarName15", _AlertVarName15, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarValue15", _AlertVarValue15, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarName16", _AlertVarName16, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarValue16", _AlertVarValue16, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarName17", _AlertVarName17, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarValue17", _AlertVarValue17, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarName18", _AlertVarName18, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarValue18", _AlertVarValue18, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarName19", _AlertVarName19, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarValue19", _AlertVarValue19, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarName20", _AlertVarName20, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertVarValue20", _AlertVarValue20, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
