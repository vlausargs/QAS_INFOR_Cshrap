//PROJECT NAME: Data
//CLASS NAME: InitModuleAUTOMATION.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleAUTOMATION : IInitModuleAUTOMATION
	{
		readonly IApplicationDB appDB;
		
		public InitModuleAUTOMATION(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleAUTOMATIONSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleAUTOMATIONSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
