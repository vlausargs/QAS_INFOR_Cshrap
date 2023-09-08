//PROJECT NAME: Production
//CLASS NAME: ApsErrorlogCleanup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsErrorlogCleanup : IApsErrorlogCleanup
	{
		readonly IApplicationDB appDB;
		
		public ApsErrorlogCleanup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsErrorlogCleanupSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsErrorlogCleanupSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
