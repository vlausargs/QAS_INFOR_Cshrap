//PROJECT NAME: CSIVendor
//CLASS NAME: InsertSupEdiParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IInsertSupEdiParms
	{
		int InsertSupEdiParmsSp();
	}
	
	public class InsertSupEdiParms : IInsertSupEdiParms
	{
		readonly IApplicationDB appDB;
		
		public InsertSupEdiParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int InsertSupEdiParmsSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InsertSupEdiParmsSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
