//PROJECT NAME: Data
//CLASS NAME: JobCoByCBuild.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobCoByCBuild : IJobCoByCBuild
	{
		readonly IApplicationDB appDB;
		
		public JobCoByCBuild(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar) JobCoByCBuildSp(
			string PJobJob,
			int? PJobSuffix,
			int? PResetTT,
			string InfoBar = null)
		{
			JobType _PJobJob = PJobJob;
			SuffixType _PJobSuffix = PJobSuffix;
			FlagNyType _PResetTT = PResetTT;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobCoByCBuildSp";
				
				appDB.AddCommandParameter(cmd, "PJobJob", _PJobJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobSuffix", _PJobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PResetTT", _PResetTT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
