//PROJECT NAME: Data
//CLASS NAME: JobsmlU.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobsmlU : IJobsmlU
	{
		readonly IApplicationDB appDB;
		
		public JobsmlU(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) JobsmlUSp(
			string Job,
			int? Suffix,
			string NewJob,
			int? NewSuffix,
			string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			JobType _NewJob = NewJob;
			SuffixType _NewSuffix = NewSuffix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobsmlUSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewJob", _NewJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewSuffix", _NewSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
