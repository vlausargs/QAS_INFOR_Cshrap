//PROJECT NAME: Data
//CLASS NAME: ApplyDynamicTables.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ApplyDynamicTables : IApplyDynamicTables
	{
		readonly IApplicationDB appDB;
		
		public ApplyDynamicTables(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApplyDynamicTablesSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApplyDynamicTablesSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
