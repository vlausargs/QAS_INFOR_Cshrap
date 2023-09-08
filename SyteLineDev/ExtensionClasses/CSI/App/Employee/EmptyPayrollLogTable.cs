//PROJECT NAME: Employee
//CLASS NAME: EmptyPayrollLogTable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class EmptyPayrollLogTable : IEmptyPayrollLogTable
	{
		readonly IApplicationDB appDB;
		
		
		public EmptyPayrollLogTable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EmptyPayrollLogTableSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EmptyPayrollLogTableSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
