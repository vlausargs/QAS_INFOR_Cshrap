//PROJECT NAME: Data
//CLASS NAME: FTApsSchedulerNeedsJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTApsSchedulerNeedsJob : IFTApsSchedulerNeedsJob
	{
		readonly IApplicationDB appDB;
		
		public FTApsSchedulerNeedsJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? FTApsSchedulerNeedsJobFn(
			string pJob,
			int? pSuffix)
		{
			JobType _pJob = pJob;
			SuffixType _pSuffix = pSuffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FTApsSchedulerNeedsJob](@pJob, @pSuffix)";
				
				appDB.AddCommandParameter(cmd, "pJob", _pJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuffix", _pSuffix, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
