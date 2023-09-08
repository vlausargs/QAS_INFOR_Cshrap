//PROJECT NAME: Production
//CLASS NAME: ApsUpdatePlannerStats.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsUpdatePlannerStats : IApsUpdatePlannerStats
	{
		readonly IApplicationDB appDB;
		
		public ApsUpdatePlannerStats(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsUpdatePlannerStatsSp(
			int? AltNo = 0)
		{
			ShortType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsUpdatePlannerStatsSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
