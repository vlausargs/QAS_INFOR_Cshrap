//PROJECT NAME: Data
//CLASS NAME: InitModuleVIETNAMCOUNTRYPACK.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleVIETNAMCOUNTRYPACK : IInitModuleVIETNAMCOUNTRYPACK
	{
		readonly IApplicationDB appDB;
		
		public InitModuleVIETNAMCOUNTRYPACK(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleVIETNAMCOUNTRYPACKSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleVIETNAMCOUNTRYPACKSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
