//PROJECT NAME: Finance
//CLASS NAME: ExtFinExportIGFBatches.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.ExtFin
{
	public class ExtFinExportIGFBatches : IExtFinExportIGFBatches
	{
		readonly IApplicationDB appDB;
		
		public ExtFinExportIGFBatches(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ExtFinExportIGFBatchesSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExtFinExportIGFBatchesSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
