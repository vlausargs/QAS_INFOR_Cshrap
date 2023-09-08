//PROJECT NAME: Data
//CLASS NAME: InitModuleCHINACOUNTRYPACK.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleCHINACOUNTRYPACK : IInitModuleCHINACOUNTRYPACK
	{
		readonly IApplicationDB appDB;
		
		public InitModuleCHINACOUNTRYPACK(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleCHINACOUNTRYPACKSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleCHINACOUNTRYPACKSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
