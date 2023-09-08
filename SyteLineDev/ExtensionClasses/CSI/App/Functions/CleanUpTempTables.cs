//PROJECT NAME: Data
//CLASS NAME: CleanUpTempTables.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CleanUpTempTables : ICleanUpTempTables
	{
		readonly IApplicationDB appDB;
		
		public CleanUpTempTables(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CleanUpTempTablesSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CleanUpTempTablesSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
