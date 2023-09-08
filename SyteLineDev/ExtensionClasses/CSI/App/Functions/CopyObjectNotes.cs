//PROJECT NAME: Data
//CLASS NAME: CopyObjectNotes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CopyObjectNotes : ICopyObjectNotes
	{
		readonly IApplicationDB appDB;
		
		public CopyObjectNotes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CopyObjectNotesSp(
			decimal? FromNoteHeaderToken,
			Guid? FromRowPointer,
			decimal? ToNoteHeaderToken,
			Guid? ToRowPointer,
			string ToObject)
		{
			TokenType _FromNoteHeaderToken = FromNoteHeaderToken;
			RowPointerType _FromRowPointer = FromRowPointer;
			TokenType _ToNoteHeaderToken = ToNoteHeaderToken;
			RowPointerType _ToRowPointer = ToRowPointer;
			StringType _ToObject = ToObject;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyObjectNotesSp";
				
				appDB.AddCommandParameter(cmd, "FromNoteHeaderToken", _FromNoteHeaderToken, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromRowPointer", _FromRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToNoteHeaderToken", _ToNoteHeaderToken, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRowPointer", _ToRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToObject", _ToObject, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
