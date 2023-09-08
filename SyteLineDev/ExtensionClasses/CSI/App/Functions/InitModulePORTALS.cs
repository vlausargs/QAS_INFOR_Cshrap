//PROJECT NAME: Data
//CLASS NAME: InitModulePORTALS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModulePORTALS : IInitModulePORTALS
	{
		readonly IApplicationDB appDB;
		
		public InitModulePORTALS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModulePORTALSSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModulePORTALSSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
