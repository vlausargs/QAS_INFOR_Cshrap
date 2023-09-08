//PROJECT NAME: Production
//CLASS NAME: ApsDelAppStr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsDelAppStr : IApsDelAppStr
	{
		readonly IApplicationDB appDB;
		
		public ApsDelAppStr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsDelAppStrSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsDelAppStrSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
