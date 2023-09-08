//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomCheckSubJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface ICopyBomCheckSubJob
	{
		int CopyBomCheckSubJobSp(string Job,
		                         short? Suffix,
		                         string JobType,
		                         ref byte? SubJob);
	}
	
	public class CopyBomCheckSubJob : ICopyBomCheckSubJob
	{
		readonly IApplicationDB appDB;
		
		public CopyBomCheckSubJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CopyBomCheckSubJobSp(string Job,
		                                short? Suffix,
		                                string JobType,
		                                ref byte? SubJob)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			JobTypeType _JobType = JobType;
			ListYesNoType _SubJob = SubJob;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyBomCheckSubJobSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubJob", _SubJob, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SubJob = _SubJob;
				
				return Severity;
			}
		}
	}
}
