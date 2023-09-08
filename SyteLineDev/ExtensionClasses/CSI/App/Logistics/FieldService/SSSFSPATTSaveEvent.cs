//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPATTSaveEvent.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSPATTSaveEvent : ISSSFSPATTSaveEvent
	{
		readonly IApplicationDB appDB;
		
		public SSSFSPATTSaveEvent(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSPATTSaveEventSp(
			Guid? MsgRowPointer,
			string FormName,
			string SentTo,
			string CC,
			string BCC,
			string Subject,
			string Body,
			string ATTList,
			string Infobar)
		{
			RowPointer _MsgRowPointer = MsgRowPointer;
			DescriptionType _FormName = FormName;
			LongListType _SentTo = SentTo;
			LongListType _CC = CC;
			LongListType _BCC = BCC;
			StringType _Subject = Subject;
			NoteType _Body = Body;
			LongDescType _ATTList = ATTList;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSPATTSaveEventSp";
				
				appDB.AddCommandParameter(cmd, "MsgRowPointer", _MsgRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FormName", _FormName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SentTo", _SentTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CC", _CC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BCC", _BCC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Subject", _Subject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Body", _Body, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ATTList", _ATTList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
