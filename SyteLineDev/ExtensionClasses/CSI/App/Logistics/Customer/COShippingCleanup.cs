//PROJECT NAME: CSICustomer
//CLASS NAME: COShippingCleanup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICOShippingCleanup
	{
		int COShippingCleanupSp();
	}
	
	public class COShippingCleanup : ICOShippingCleanup
	{
		readonly IApplicationDB appDB;
		
		public COShippingCleanup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int COShippingCleanupSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "COShippingCleanupSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
