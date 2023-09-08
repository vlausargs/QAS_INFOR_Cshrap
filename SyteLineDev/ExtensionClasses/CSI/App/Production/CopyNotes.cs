//PROJECT NAME: Production
//CLASS NAME: CopyNotes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CopyNotes : ICopyNotes
	{
		readonly IApplicationDB appDB;
		
		
		public CopyNotes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CopyNotesSp(string FromObject,
		Guid? FromRowPointer,
		string ToObject,
		Guid? ToRowPointer)
		{
			StringType _FromObject = FromObject;
			RowPointerType _FromRowPointer = FromRowPointer;
			StringType _ToObject = ToObject;
			RowPointerType _ToRowPointer = ToRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyNotesSp";
				
				appDB.AddCommandParameter(cmd, "FromObject", _FromObject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromRowPointer", _FromRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToObject", _ToObject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRowPointer", _ToRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
