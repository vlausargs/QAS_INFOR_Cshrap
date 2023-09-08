//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXDummy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSRMXDummy : ISSSRMXDummy
	{
		readonly IApplicationDB appDB;
		
		
		public SSSRMXDummy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSRMXDummySp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRMXDummySp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
