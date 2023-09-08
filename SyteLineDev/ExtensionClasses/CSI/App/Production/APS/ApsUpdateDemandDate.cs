//PROJECT NAME: Production
//CLASS NAME: ApsUpdateDemandDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsUpdateDemandDate : IApsUpdateDemandDate
	{
		readonly IApplicationDB appDB;
		
		public ApsUpdateDemandDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsUpdateDemandDateSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsUpdateDemandDateSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
