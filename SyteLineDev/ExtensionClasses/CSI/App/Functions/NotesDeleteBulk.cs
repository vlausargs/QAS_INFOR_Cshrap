//PROJECT NAME: Data
//CLASS NAME: NotesDeleteBulk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NotesDeleteBulk : INotesDeleteBulk
	{
		readonly IApplicationDB appDB;
		
		public NotesDeleteBulk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? NotesDeleteBulkSp(
			string Object)
		{
			StringType _Object = Object;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NotesDeleteBulkSp";
				
				appDB.AddCommandParameter(cmd, "Object", _Object, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
