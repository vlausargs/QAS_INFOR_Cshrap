//PROJECT NAME: Data
//CLASS NAME: InitModuleTAXINTERFACE.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleTAXINTERFACE : IInitModuleTAXINTERFACE
	{
		readonly IApplicationDB appDB;
		
		public InitModuleTAXINTERFACE(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleTAXINTERFACESp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleTAXINTERFACESp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
