//PROJECT NAME: Data
//CLASS NAME: Load_setuprgid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Load_setuprgid : ILoad_setuprgid
	{
		readonly IApplicationDB appDB;
		
		public Load_setuprgid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Load_setuprgidSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Load_setuprgid";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
