//PROJECT NAME: Data
//CLASS NAME: JobOrdersEnableCoProductMix.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobOrdersEnableCoProductMix : IJobOrdersEnableCoProductMix
	{
		readonly IApplicationDB appDB;
		
		public JobOrdersEnableCoProductMix(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? JobOrdersEnableCoProductMixFn(
			string Stat,
			string Job,
			int? Suffix,
			string RootJob,
			int? RootSuffix,
			string RefJob,
			int? RefSuffix)
		{
			JobStatusType _Stat = Stat;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			JobType _RootJob = RootJob;
			SuffixType _RootSuffix = RootSuffix;
			JobType _RefJob = RefJob;
			SuffixType _RefSuffix = RefSuffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[JobOrdersEnableCoProductMix](@Stat, @Job, @Suffix, @RootJob, @RootSuffix, @RefJob, @RefSuffix)";
				
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RootJob", _RootJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RootSuffix", _RootSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefJob", _RefJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefSuffix", _RefSuffix, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
