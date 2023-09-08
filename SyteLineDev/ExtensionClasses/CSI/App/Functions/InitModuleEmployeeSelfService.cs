//PROJECT NAME: Data
//CLASS NAME: InitModuleEMPLOYEESELFSERVICE.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleEMPLOYEESELFSERVICE : IInitModuleEMPLOYEESELFSERVICE
	{
		readonly IApplicationDB appDB;
		
		public InitModuleEMPLOYEESELFSERVICE(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleEMPLOYEESELFSERVICESp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleEMPLOYEESELFSERVICESp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
