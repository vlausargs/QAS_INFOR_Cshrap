//PROJECT NAME: Production
//CLASS NAME: PmfFmUpdUsage.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmUpdUsage : IPmfFmUpdUsage
	{
		readonly IApplicationDB appDB;
		
		public PmfFmUpdUsage(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfFmUpdUsageSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfFmUpdUsageSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
