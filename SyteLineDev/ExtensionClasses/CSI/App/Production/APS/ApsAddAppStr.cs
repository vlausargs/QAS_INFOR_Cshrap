//PROJECT NAME: Production
//CLASS NAME: ApsAddAppStr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsAddAppStr : IApsAddAppStr
	{
		readonly IApplicationDB appDB;
		
		public ApsAddAppStr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsAddAppStrSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsAddAppStrSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
