//PROJECT NAME: Data
//CLASS NAME: EdiOutCopyNotes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiOutCopyNotes : IEdiOutCopyNotes
	{
		readonly IApplicationDB appDB;
		
		public EdiOutCopyNotes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EdiOutCopyNotesSp(
			string FromObject,
			Guid? FromRowPointer)
		{
			StringType _FromObject = FromObject;
			RowPointerType _FromRowPointer = FromRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiOutCopyNotesSp";
				
				appDB.AddCommandParameter(cmd, "FromObject", _FromObject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromRowPointer", _FromRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
