//PROJECT NAME: Production
//CLASS NAME: BOMBulkImport_CreateJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class BOMBulkImport_CreateJob : IBOMBulkImport_CreateJob
	{
		readonly IApplicationDB appDB;
		
		public BOMBulkImport_CreateJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? BOMBulkImport_CreateJobSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BOMBulkImport_CreateJobSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
