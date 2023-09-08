//PROJECT NAME: Logistics
//CLASS NAME: CreateSourceCommunication.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CreateSourceCommunication : ICreateSourceCommunication
	{
		readonly IApplicationDB appDB;
		
		
		public CreateSourceCommunication(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CreateSourceCommunicationSp(string SourceType,
		string SourceKey,
		string Topic,
		string Type,
		string Note,
		int? ShowContent,
		string Input)
		{
			StringType _SourceType = SourceType;
			StringType _SourceKey = SourceKey;
			CommLogTopicType _Topic = Topic;
			CommLogTypeType _Type = Type;
			CommLogNotesType _Note = Note;
			ByteType _ShowContent = ShowContent;
			CommLogNotesType _Input = Input;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateSourceCommunicationSp";
				
				appDB.AddCommandParameter(cmd, "SourceType", _SourceType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceKey", _SourceKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Topic", _Topic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Note", _Note, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowContent", _ShowContent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Input", _Input, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
