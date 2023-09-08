//PROJECT NAME: Production
//CLASS NAME: JobrouteExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobrouteExists : IJobrouteExists
	{
		readonly IApplicationDB appDB;
		
		
		public JobrouteExists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? JobrouteExists) JobrouteExistsSp(string Job,
		int? Suffix,
		int? JobrouteExists)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			ListYesNoType _JobrouteExists = JobrouteExists;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobrouteExistsSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteExists", _JobrouteExists, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				JobrouteExists = _JobrouteExists;
				
				return (Severity, JobrouteExists);
			}
		}

		public int? JobrouteExistsFn(
			string Job,
			int? Suffix)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[JobrouteExists](@Job, @Suffix)";

				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}
	}
}
