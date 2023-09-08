//PROJECT NAME: Data
//CLASS NAME: InitModuleMOBILE_MS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleMOBILE_MS : IInitModuleMOBILE_MS
	{
		readonly IApplicationDB appDB;
		
		public InitModuleMOBILE_MS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleMOBILE_MSSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleMOBILE_MSSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
