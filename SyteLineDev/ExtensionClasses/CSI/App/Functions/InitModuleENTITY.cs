//PROJECT NAME: Data
//CLASS NAME: InitModuleENTITY.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleENTITY : IInitModuleENTITY
	{
		readonly IApplicationDB appDB;
		
		public InitModuleENTITY(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleENTITYSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleENTITYSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
