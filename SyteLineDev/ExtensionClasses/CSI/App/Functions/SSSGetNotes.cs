//PROJECT NAME: Data
//CLASS NAME: SSSGetNotes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SSSGetNotes : ISSSGetNotes
	{
		readonly IApplicationDB appDB;
		
		public SSSGetNotes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSGetNotesFn(
			Guid? RowPointer)
		{
			RowPointerType _RowPointer = RowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSGetNotes](@RowPointer)";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
