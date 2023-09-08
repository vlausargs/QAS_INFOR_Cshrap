//PROJECT NAME: Production
//CLASS NAME: PmfFmGetUsage.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmGetUsage : IPmfFmGetUsage
	{
		readonly IApplicationDB appDB;
		
		public PmfFmGetUsage(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfFmGetUsageSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfFmGetUsageSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
