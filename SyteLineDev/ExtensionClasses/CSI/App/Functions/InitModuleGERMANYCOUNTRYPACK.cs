//PROJECT NAME: Data
//CLASS NAME: InitModuleGERMANYCOUNTRYPACK.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleGERMANYCOUNTRYPACK : IInitModuleGERMANYCOUNTRYPACK
	{
		readonly IApplicationDB appDB;
		
		public InitModuleGERMANYCOUNTRYPACK(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleGERMANYCOUNTRYPACKSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleGERMANYCOUNTRYPACKSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
