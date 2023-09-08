//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCopySyncNotes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSroCopySyncNotes : ISSSFSSroCopySyncNotes
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroCopySyncNotes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSSroCopySyncNotesSp(
			Guid? FromRowPointer,
			string FromTableName,
			Guid? ToRowPointer,
			string ToTableName,
			int? InsertObjectNote,
			string Infobar)
		{
			RowPointerType _FromRowPointer = FromRowPointer;
			StringType _FromTableName = FromTableName;
			RowPointerType _ToRowPointer = ToRowPointer;
			StringType _ToTableName = ToTableName;
			ListYesNoType _InsertObjectNote = InsertObjectNote;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroCopySyncNotesSp";
				
				appDB.AddCommandParameter(cmd, "FromRowPointer", _FromRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTableName", _FromTableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRowPointer", _ToRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTableName", _ToTableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InsertObjectNote", _InsertObjectNote, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
