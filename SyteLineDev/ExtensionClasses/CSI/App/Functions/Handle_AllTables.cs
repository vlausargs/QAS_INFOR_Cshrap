//PROJECT NAME: Data
//CLASS NAME: Handle_AllTables.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Handle_AllTables : IHandle_AllTables
	{
		readonly IApplicationDB appDB;
		
		public Handle_AllTables(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Handle_AllTablesSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Handle_AllTablesSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
