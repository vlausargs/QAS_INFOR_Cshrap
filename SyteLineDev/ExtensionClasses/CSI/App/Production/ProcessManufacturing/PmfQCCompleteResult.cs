//PROJECT NAME: Production
//CLASS NAME: PmfQCCompleteResult.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfQCCompleteResult : IPmfQCCompleteResult
	{
		readonly IApplicationDB appDB;
		
		public PmfQCCompleteResult(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfQCCompleteResultSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfQCCompleteResultSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
