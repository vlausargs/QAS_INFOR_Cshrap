//PROJECT NAME: Logistics
//CLASS NAME: CreateContactEmailCommunication.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CreateContactEmailCommunication : ICreateContactEmailCommunication
	{
		readonly IApplicationDB appDB;
		
		
		public CreateContactEmailCommunication(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CreateContactEmailCommunicationSp(string Topic,
		string Type,
		string Note,
		string ShowContent,
		string Input,
		string ContactId,
		string EmailSubject)
		{
			CommLogTopicType _Topic = Topic;
			CommLogTypeType _Type = Type;
			CommLogNotesType _Note = Note;
			StringType _ShowContent = ShowContent;
			CommLogNotesType _Input = Input;
			ContactIDType _ContactId = ContactId;
			MessageSubjectType _EmailSubject = EmailSubject;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateContactEmailCommunicationSp";
				
				appDB.AddCommandParameter(cmd, "Topic", _Topic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Note", _Note, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowContent", _ShowContent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Input", _Input, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContactId", _ContactId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmailSubject", _EmailSubject, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
