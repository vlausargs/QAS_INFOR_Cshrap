//PROJECT NAME: Data
//CLASS NAME: InitModuleTRANSACTIONAL.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleTRANSACTIONAL : IInitModuleTRANSACTIONAL
	{
		readonly IApplicationDB appDB;
		
		public InitModuleTRANSACTIONAL(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleTRANSACTIONALSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleTRANSACTIONALSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
