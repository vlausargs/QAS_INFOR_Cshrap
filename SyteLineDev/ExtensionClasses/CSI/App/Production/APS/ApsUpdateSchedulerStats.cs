//PROJECT NAME: Production
//CLASS NAME: ApsUpdateSchedulerStats.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsUpdateSchedulerStats : IApsUpdateSchedulerStats
	{
		readonly IApplicationDB appDB;
		
		public ApsUpdateSchedulerStats(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsUpdateSchedulerStatsSp(
			int? AltNo = 0)
		{
			ShortType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsUpdateSchedulerStatsSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
