//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBNotes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBNotes
	{
		int LoadESBNotesSp(string TableName,
		                   Guid? RowPointer,
		                   byte? IsInternalNote,
		                   string NoteDesc,
		                   string NoteText,
		                   ref string Infobar,
                           short? CoLine);
	}
	
	public class LoadESBNotes : ILoadESBNotes
	{
		readonly IApplicationDB appDB;
		
		public LoadESBNotes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBNotesSp(string TableName,
		                          Guid? RowPointer,
		                          byte? IsInternalNote,
		                          string NoteDesc,
		                          string NoteText,
		                          ref string Infobar,
                                  short? CoLine)
		{
			StringType _TableName = TableName;
			RowPointerType _RowPointer = RowPointer;
			FlagNyType _IsInternalNote = IsInternalNote;
			LongDescType _NoteDesc = NoteDesc;
			LongListType _NoteText = NoteText;
			InfobarType _Infobar = Infobar;
            CoLineType _CoLine = CoLine;


            using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBNotesSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsInternalNote", _IsInternalNote, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteDesc", _NoteDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteText", _NoteText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
                var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
