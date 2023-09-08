//PROJECT NAME: Data
//CLASS NAME: InitModuleCRM_MS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleCRM_MS : IInitModuleCRM_MS
	{
		readonly IApplicationDB appDB;
		
		public InitModuleCRM_MS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleCRM_MSSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleCRM_MSSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
