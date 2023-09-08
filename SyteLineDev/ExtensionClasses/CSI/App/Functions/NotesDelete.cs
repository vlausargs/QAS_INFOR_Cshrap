//PROJECT NAME: Data
//CLASS NAME: NotesDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NotesDelete : INotesDelete
	{
		readonly IApplicationDB appDB;
		
		public NotesDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? NotesDeleteSp(
			string Object,
			Guid? RowPointer)
		{
			StringType _Object = Object;
			RowPointerType _RowPointer = RowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NotesDeleteSp";
				
				appDB.AddCommandParameter(cmd, "Object", _Object, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
