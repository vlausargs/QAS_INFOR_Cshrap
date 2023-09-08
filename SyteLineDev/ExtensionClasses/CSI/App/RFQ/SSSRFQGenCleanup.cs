//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQGenCleanup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQGenCleanup : ISSSRFQGenCleanup
	{
		readonly IApplicationDB appDB;
		
		
		public SSSRFQGenCleanup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSRFQGenCleanupSp(string PSessionId)
		{
			StringType _PSessionId = PSessionId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQGenCleanupSp";
				
				appDB.AddCommandParameter(cmd, "PSessionId", _PSessionId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
