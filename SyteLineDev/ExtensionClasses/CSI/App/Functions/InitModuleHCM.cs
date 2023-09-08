//PROJECT NAME: Data
//CLASS NAME: InitModuleHCM.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleHCM : IInitModuleHCM
	{
		readonly IApplicationDB appDB;
		
		public InitModuleHCM(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleHCMSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleHCMSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
