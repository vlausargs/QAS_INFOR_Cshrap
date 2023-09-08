//PROJECT NAME: Production
//CLASS NAME: ApsGetStringInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetStringInfo : IApsGetStringInfo
	{
		readonly IApplicationDB appDB;
		
		public ApsGetStringInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsGetStringInfoSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsGetStringInfoSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
