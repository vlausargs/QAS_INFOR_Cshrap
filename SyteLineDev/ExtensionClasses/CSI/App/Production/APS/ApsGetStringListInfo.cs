//PROJECT NAME: Production
//CLASS NAME: ApsGetStringListInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetStringListInfo : IApsGetStringListInfo
	{
		readonly IApplicationDB appDB;
		
		public ApsGetStringListInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsGetStringListInfoSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsGetStringListInfoSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
