//PROJECT NAME: Production
//CLASS NAME: PmfDltUnusedReportSessions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfDltUnusedReportSessions : IPmfDltUnusedReportSessions
	{
		readonly IApplicationDB appDB;
		
		public PmfDltUnusedReportSessions(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfDltUnusedReportSessionsSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfDltUnusedReportSessionsSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
