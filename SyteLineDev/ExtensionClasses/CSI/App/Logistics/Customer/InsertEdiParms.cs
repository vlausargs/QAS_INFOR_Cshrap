//PROJECT NAME: CSICustomer
//CLASS NAME: InsertEdiParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IInsertEdiParms
	{
		int InsertEdiParmsSp();
	}
	
	public class InsertEdiParms : IInsertEdiParms
	{
		readonly IApplicationDB appDB;
		
		public InsertEdiParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int InsertEdiParmsSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InsertEdiParmsSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
