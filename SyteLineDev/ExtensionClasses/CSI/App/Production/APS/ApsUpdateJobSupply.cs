//PROJECT NAME: Production
//CLASS NAME: ApsUpdateJobSupply.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsUpdateJobSupply : IApsUpdateJobSupply
	{
		readonly IApplicationDB appDB;
		
		public ApsUpdateJobSupply(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsUpdateJobSupplySp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsUpdateJobSupplySp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
