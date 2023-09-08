//PROJECT NAME: Data
//CLASS NAME: InitModuleCREDITCARDINTERFACE.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitModuleCREDITCARDINTERFACE : IInitModuleCREDITCARDINTERFACE
	{
		readonly IApplicationDB appDB;
		
		public InitModuleCREDITCARDINTERFACE(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InitModuleCREDITCARDINTERFACESp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitModuleCREDITCARDINTERFACESp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
