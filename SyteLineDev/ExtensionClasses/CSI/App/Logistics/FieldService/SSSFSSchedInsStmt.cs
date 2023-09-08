//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedInsStmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSchedInsStmt : ISSSFSSchedInsStmt
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSchedInsStmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSSchedInsStmtFn(
			Guid? RowPointer)
		{
			RowPointerType _RowPointer = RowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSSchedInsStmt](@RowPointer)";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
