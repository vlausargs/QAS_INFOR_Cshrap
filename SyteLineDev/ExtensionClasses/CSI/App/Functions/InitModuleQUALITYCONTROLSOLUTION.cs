//PROJECT NAME: Data
//CLASS NAME: InitModuleQUALITYCONTROLSOLUTION.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleQUALITYCONTROLSOLUTION : IInitModuleQUALITYCONTROLSOLUTION
	{
		readonly IApplicationDB appDB;
		
		public InitModuleQUALITYCONTROLSOLUTION(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleQUALITYCONTROLSOLUTIONSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleQUALITYCONTROLSOLUTIONSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
