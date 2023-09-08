//PROJECT NAME: Data
//CLASS NAME: InitModulePORTALS_MS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModulePORTALS_MS : IInitModulePORTALS_MS
	{
		readonly IApplicationDB appDB;
		
		public InitModulePORTALS_MS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModulePORTALS_MSSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModulePORTALS_MSSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
