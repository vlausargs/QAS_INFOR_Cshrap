//PROJECT NAME: Config
//CLASS NAME: CfgDeleteNotes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgDeleteNotes : ICfgDeleteNotes
	{
		readonly IApplicationDB appDB;
		
		public CfgDeleteNotes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CfgDeleteNotesSp(
			Guid? RowPointer)
		{
			RowPointerType _RowPointer = RowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgDeleteNotesSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
