//PROJECT NAME: Data
//CLASS NAME: InitModuleASSETMANAGEMENT_MS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleASSETMANAGEMENT_MS : IInitModuleASSETMANAGEMENT_MS
	{
		readonly IApplicationDB appDB;
		
		public InitModuleASSETMANAGEMENT_MS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleASSETMANAGEMENT_MSSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleASSETMANAGEMENT_MSSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
