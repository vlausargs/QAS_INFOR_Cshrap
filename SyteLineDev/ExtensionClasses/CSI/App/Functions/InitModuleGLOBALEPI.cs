//PROJECT NAME: Data
//CLASS NAME: InitModuleGLOBALEPI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleGLOBALEPI : IInitModuleGLOBALEPI
	{
		readonly IApplicationDB appDB;
		
		public InitModuleGLOBALEPI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleGLOBALEPISp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleGLOBALEPISp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
