//PROJECT NAME: Data
//CLASS NAME: InitModuleCRM.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleCRM : IInitModuleCRM
	{
		readonly IApplicationDB appDB;
		
		public InitModuleCRM(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleCRMSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleCRMSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
