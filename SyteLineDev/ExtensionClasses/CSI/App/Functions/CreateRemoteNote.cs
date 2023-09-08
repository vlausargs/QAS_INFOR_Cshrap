//PROJECT NAME: Data
//CLASS NAME: CreateRemoteNote.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CreateRemoteNote : ICreateRemoteNote
	{
		readonly IApplicationDB appDB;
		
		public CreateRemoteNote(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CreateRemoteNoteSp(
			string TableName,
			Guid? RowPointer,
			string ReportNotesViewDescription,
			string ReportNotesViewNote,
			int? ReportNotesViewIsInternalNote,
			string Infobar)
		{
			TableNameType _TableName = TableName;
			RowPointerType _RowPointer = RowPointer;
			LongDescType _ReportNotesViewDescription = ReportNotesViewDescription;
			LongListType _ReportNotesViewNote = ReportNotesViewNote;
			FlagIeType _ReportNotesViewIsInternalNote = ReportNotesViewIsInternalNote;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateRemoteNoteSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReportNotesViewDescription", _ReportNotesViewDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReportNotesViewNote", _ReportNotesViewNote, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReportNotesViewIsInternalNote", _ReportNotesViewIsInternalNote, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
