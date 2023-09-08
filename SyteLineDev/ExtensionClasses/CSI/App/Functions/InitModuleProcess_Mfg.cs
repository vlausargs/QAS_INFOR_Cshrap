//PROJECT NAME: Data
//CLASS NAME: InitModulePROCESS_MFG.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModulePROCESS_MFG : IInitModulePROCESS_MFG
	{
		readonly IApplicationDB appDB;
		
		public InitModulePROCESS_MFG(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModulePROCESS_MFGSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModulePROCESS_MFGSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
