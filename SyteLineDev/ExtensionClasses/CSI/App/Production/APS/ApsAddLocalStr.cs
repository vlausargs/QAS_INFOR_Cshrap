//PROJECT NAME: Production
//CLASS NAME: ApsAddLocalStr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsAddLocalStr : IApsAddLocalStr
	{
		readonly IApplicationDB appDB;
		
		public ApsAddLocalStr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsAddLocalStrSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsAddLocalStrSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
