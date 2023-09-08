//PROJECT NAME: Data
//CLASS NAME: MakeRemoteObjectNotesCrossTable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MakeRemoteObjectNotesCrossTable : IMakeRemoteObjectNotesCrossTable
	{
		readonly IApplicationDB appDB;
		
		public MakeRemoteObjectNotesCrossTable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MakeRemoteObjectNotesCrossTableSp(
			string FromSite,
			string TableName,
			string ToWhereClause,
			string ToJoinClause,
			Guid? ToRowPointer,
			string TypeOfNote,
			decimal? FromToken,
			int? NoteType,
			int? NoteFlag,
			string Infobar,
			decimal? ToNoteToken)
		{
			SiteType _FromSite = FromSite;
			StringType _TableName = TableName;
			LongListType _ToWhereClause = ToWhereClause;
			LongListType _ToJoinClause = ToJoinClause;
			RowPointerType _ToRowPointer = ToRowPointer;
			TypeOfNoteType _TypeOfNote = TypeOfNote;
			TokenType _FromToken = FromToken;
			GenericTypeType _NoteType = NoteType;
			FlagIeType _NoteFlag = NoteFlag;
			InfobarType _Infobar = Infobar;
			TokenType _ToNoteToken = ToNoteToken;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MakeRemoteObjectNotesCrossTableSp";
				
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhereClause", _ToWhereClause, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJoinClause", _ToJoinClause, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRowPointer", _ToRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TypeOfNote", _TypeOfNote, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromToken", _FromToken, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteType", _NoteType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteFlag", _NoteFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToNoteToken", _ToNoteToken, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
