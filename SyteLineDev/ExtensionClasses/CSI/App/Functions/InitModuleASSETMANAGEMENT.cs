//PROJECT NAME: Data
//CLASS NAME: InitModuleASSETMANAGEMENT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleASSETMANAGEMENT : IInitModuleASSETMANAGEMENT
	{
		readonly IApplicationDB appDB;
		
		public InitModuleASSETMANAGEMENT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleASSETMANAGEMENTSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleASSETMANAGEMENTSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
