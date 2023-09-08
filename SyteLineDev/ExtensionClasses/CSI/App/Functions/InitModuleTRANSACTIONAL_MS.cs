//PROJECT NAME: Data
//CLASS NAME: InitModuleTRANSACTIONAL_MS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleTRANSACTIONAL_MS : IInitModuleTRANSACTIONAL_MS
	{
		readonly IApplicationDB appDB;
		
		public InitModuleTRANSACTIONAL_MS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleTRANSACTIONAL_MSSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleTRANSACTIONAL_MSSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
