//PROJECT NAME: Production
//CLASS NAME: ApsJobOrderStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsJobOrderStatus : IApsJobOrderStatus
	{
		readonly IApplicationDB appDB;
		
		
		public ApsJobOrderStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PStatus) ApsJobOrderStatusSp(string PJob,
		int? PSuffix,
		int? PStatus)
		{
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			IntType _PStatus = PStatus;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsJobOrderStatusSp";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStatus", _PStatus, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PStatus = _PStatus;
				
				return (Severity, PStatus);
			}
		}
	}
}
