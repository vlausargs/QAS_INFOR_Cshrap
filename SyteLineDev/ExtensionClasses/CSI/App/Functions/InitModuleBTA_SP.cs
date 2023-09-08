//PROJECT NAME: Data
//CLASS NAME: InitModuleBTA_SP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleBTA_SP : IInitModuleBTA_SP
	{
		readonly IApplicationDB appDB;
		
		public InitModuleBTA_SP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleBTA_SPSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleBTA_SPSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
