//PROJECT NAME: Production
//CLASS NAME: JobRouteDeleteResourceGrp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobRouteDeleteResourceGrp : IJobRouteDeleteResourceGrp
	{
		readonly IApplicationDB appDB;
		
		
		public JobRouteDeleteResourceGrp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? JobRouteDeleteResourceGrpSp(string PJob,
		int? PSuffix,
		int? POperNum)
		{
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			OperNumType _POperNum = POperNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobRouteDeleteResourceGrpSp";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POperNum", _POperNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
