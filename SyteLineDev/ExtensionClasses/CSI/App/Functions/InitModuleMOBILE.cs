//PROJECT NAME: Data
//CLASS NAME: InitModuleMOBILE.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleMOBILE : IInitModuleMOBILE
	{
		readonly IApplicationDB appDB;
		
		public InitModuleMOBILE(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleMOBILESp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleMOBILESp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
