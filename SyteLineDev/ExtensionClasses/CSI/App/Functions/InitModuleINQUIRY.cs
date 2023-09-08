//PROJECT NAME: Data
//CLASS NAME: InitModuleINQUIRY.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleINQUIRY : IInitModuleINQUIRY
	{
		readonly IApplicationDB appDB;
		
		public InitModuleINQUIRY(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleINQUIRYSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleINQUIRYSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
