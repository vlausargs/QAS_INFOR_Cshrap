//PROJECT NAME: Data
//CLASS NAME: JobCoByBuild.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobCoByBuild : IJobCoByBuild
	{
		readonly IApplicationDB appDB;
		
		public JobCoByBuild(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) JobCoByBuildSp(
			string JobJob,
			int? JobSuffix,
			string Infobar)
		{
			JobType _JobJob = JobJob;
			SuffixType _JobSuffix = JobSuffix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobCoByBuildSp";
				
				appDB.AddCommandParameter(cmd, "JobJob", _JobJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
