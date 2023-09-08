//PROJECT NAME: Production
//CLASS NAME: ApsSchedulerCompleted.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSchedulerCompleted : IApsSchedulerCompleted
	{
		readonly IApplicationDB appDB;
		
		public ApsSchedulerCompleted(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSchedulerCompletedSp(
			int? AltNo)
		{
			ShortType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsSchedulerCompletedSp";
				
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
