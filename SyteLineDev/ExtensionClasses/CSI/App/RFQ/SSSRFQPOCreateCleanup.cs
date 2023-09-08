//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQPOCreateCleanup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQPOCreateCleanup : ISSSRFQPOCreateCleanup
	{
		readonly IApplicationDB appDB;
		
		
		public SSSRFQPOCreateCleanup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSRFQPOCreateCleanupSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQPOCreateCleanupSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
