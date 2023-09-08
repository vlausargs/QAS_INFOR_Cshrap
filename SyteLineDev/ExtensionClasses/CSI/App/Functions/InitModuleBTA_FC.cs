//PROJECT NAME: Data
//CLASS NAME: InitModuleBTA_FC.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleBTA_FC : IInitModuleBTA_FC
	{
		readonly IApplicationDB appDB;
		
		public InitModuleBTA_FC(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleBTA_FCSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleBTA_FCSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
