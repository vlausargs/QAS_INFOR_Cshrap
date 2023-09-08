//PROJECT NAME: Data
//CLASS NAME: InitModuleDEVELOPER.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleDEVELOPER : IInitModuleDEVELOPER
	{
		readonly IApplicationDB appDB;
		
		public InitModuleDEVELOPER(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleDEVELOPERSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleDEVELOPERSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
