//PROJECT NAME: Data
//CLASS NAME: NotifyPublicationSubscribersWithBOD.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NotifyPublicationSubscribersWithBOD : INotifyPublicationSubscribersWithBOD
	{
		readonly IApplicationDB appDB;
		
		public NotifyPublicationSubscribersWithBOD(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) NotifyPublicationSubscribersWithBODSp(
			string PublicationName = null,
			string AlertSubject = null,
			string AlertMsg = null,
			string AlertHTMLMsg = null,
			string Infobar = null,
			string KeyValue = null,
			string AlertSubjectParm1 = null,
			string AlertSubjectParm2 = null,
			string AlertSubjectParm3 = null,
			string AlertSubjectParm4 = null,
			string AlertSubjectParm5 = null,
			string AlertSubjectParm6 = null,
			string AlertSubjectParm7 = null,
			string AlertSubjectParm8 = null,
			string AlertSubjectParm9 = null,
			string AlertSubjectParm10 = null,
			string AlertSubjectParm11 = null,
			string AlertSubjectParm12 = null,
			string AlertSubjectParm13 = null,
			string AlertSubjectParm14 = null,
			string AlertSubjectParm15 = null,
			string AlertMsgParm1 = null,
			string AlertMsgParm2 = null,
			string AlertMsgParm3 = null,
			string AlertMsgParm4 = null,
			string AlertMsgParm5 = null,
			string AlertMsgParm6 = null,
			string AlertMsgParm7 = null,
			string AlertMsgParm8 = null,
			string AlertMsgParm9 = null,
			string AlertMsgParm10 = null,
			string AlertMsgParm11 = null,
			string AlertMsgParm12 = null,
			string AlertMsgParm13 = null,
			string AlertMsgParm14 = null,
			string AlertMsgParm15 = null,
			string Category = null,
			string AlertMsgDescription = null)
		{
			NameType _PublicationName = PublicationName;
			NoteType _AlertSubject = AlertSubject;
			NoteType _AlertMsg = AlertMsg;
			NoteType _AlertHTMLMsg = AlertHTMLMsg;
			InfobarType _Infobar = Infobar;
			KeyValueType _KeyValue = KeyValue;
			NoteType _AlertSubjectParm1 = AlertSubjectParm1;
			NoteType _AlertSubjectParm2 = AlertSubjectParm2;
			NoteType _AlertSubjectParm3 = AlertSubjectParm3;
			NoteType _AlertSubjectParm4 = AlertSubjectParm4;
			NoteType _AlertSubjectParm5 = AlertSubjectParm5;
			NoteType _AlertSubjectParm6 = AlertSubjectParm6;
			NoteType _AlertSubjectParm7 = AlertSubjectParm7;
			NoteType _AlertSubjectParm8 = AlertSubjectParm8;
			NoteType _AlertSubjectParm9 = AlertSubjectParm9;
			NoteType _AlertSubjectParm10 = AlertSubjectParm10;
			NoteType _AlertSubjectParm11 = AlertSubjectParm11;
			NoteType _AlertSubjectParm12 = AlertSubjectParm12;
			NoteType _AlertSubjectParm13 = AlertSubjectParm13;
			NoteType _AlertSubjectParm14 = AlertSubjectParm14;
			NoteType _AlertSubjectParm15 = AlertSubjectParm15;
			NoteType _AlertMsgParm1 = AlertMsgParm1;
			NoteType _AlertMsgParm2 = AlertMsgParm2;
			NoteType _AlertMsgParm3 = AlertMsgParm3;
			NoteType _AlertMsgParm4 = AlertMsgParm4;
			NoteType _AlertMsgParm5 = AlertMsgParm5;
			NoteType _AlertMsgParm6 = AlertMsgParm6;
			NoteType _AlertMsgParm7 = AlertMsgParm7;
			NoteType _AlertMsgParm8 = AlertMsgParm8;
			NoteType _AlertMsgParm9 = AlertMsgParm9;
			NoteType _AlertMsgParm10 = AlertMsgParm10;
			NoteType _AlertMsgParm11 = AlertMsgParm11;
			NoteType _AlertMsgParm12 = AlertMsgParm12;
			NoteType _AlertMsgParm13 = AlertMsgParm13;
			NoteType _AlertMsgParm14 = AlertMsgParm14;
			NoteType _AlertMsgParm15 = AlertMsgParm15;
			MessageCategoryType _Category = Category;
			NoteType _AlertMsgDescription = AlertMsgDescription;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NotifyPublicationSubscribersWithBODSp";
				
				appDB.AddCommandParameter(cmd, "PublicationName", _PublicationName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertSubject", _AlertSubject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertMsg", _AlertMsg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertHTMLMsg", _AlertHTMLMsg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "KeyValue", _KeyValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertSubjectParm1", _AlertSubjectParm1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertSubjectParm2", _AlertSubjectParm2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertSubjectParm3", _AlertSubjectParm3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertSubjectParm4", _AlertSubjectParm4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertSubjectParm5", _AlertSubjectParm5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertSubjectParm6", _AlertSubjectParm6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertSubjectParm7", _AlertSubjectParm7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertSubjectParm8", _AlertSubjectParm8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertSubjectParm9", _AlertSubjectParm9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertSubjectParm10", _AlertSubjectParm10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertSubjectParm11", _AlertSubjectParm11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertSubjectParm12", _AlertSubjectParm12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertSubjectParm13", _AlertSubjectParm13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertSubjectParm14", _AlertSubjectParm14, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertSubjectParm15", _AlertSubjectParm15, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertMsgParm1", _AlertMsgParm1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertMsgParm2", _AlertMsgParm2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertMsgParm3", _AlertMsgParm3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertMsgParm4", _AlertMsgParm4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertMsgParm5", _AlertMsgParm5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertMsgParm6", _AlertMsgParm6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertMsgParm7", _AlertMsgParm7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertMsgParm8", _AlertMsgParm8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertMsgParm9", _AlertMsgParm9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertMsgParm10", _AlertMsgParm10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertMsgParm11", _AlertMsgParm11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertMsgParm12", _AlertMsgParm12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertMsgParm13", _AlertMsgParm13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertMsgParm14", _AlertMsgParm14, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertMsgParm15", _AlertMsgParm15, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Category", _Category, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlertMsgDescription", _AlertMsgDescription, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
