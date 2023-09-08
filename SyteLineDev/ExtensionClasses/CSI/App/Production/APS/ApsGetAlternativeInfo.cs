//PROJECT NAME: Production
//CLASS NAME: ApsGetAlternativeInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetAlternativeInfo : IApsGetAlternativeInfo
	{
		readonly IApplicationDB appDB;
		
		public ApsGetAlternativeInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsGetAlternativeInfoSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsGetAlternativeInfoSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
