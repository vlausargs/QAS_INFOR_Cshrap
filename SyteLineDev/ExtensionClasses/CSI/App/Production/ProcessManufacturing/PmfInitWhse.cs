//PROJECT NAME: Production
//CLASS NAME: PmfInitWhse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfInitWhse : IPmfInitWhse
	{
		readonly IApplicationDB appDB;
		
		public PmfInitWhse(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PmfInitWhseSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfInitWhseSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
