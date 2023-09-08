//PROJECT NAME: Data
//CLASS NAME: APP_PopulateNextKeys.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class APP_PopulateNextKeys : IAPP_PopulateNextKeys
	{
		readonly IApplicationDB appDB;
		
		public APP_PopulateNextKeys(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? APP_PopulateNextKeysSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "APP_PopulateNextKeysSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
