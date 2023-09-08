//PROJECT NAME: Data
//CLASS NAME: IsScheduled.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsScheduled : IIsScheduled
	{
		readonly IApplicationDB appDB;
		
		public IsScheduled(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsScheduledFn(
			string pJob,
			int? pSuffix)
		{
			JobType _pJob = pJob;
			SuffixType _pSuffix = pSuffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsScheduled](@pJob, @pSuffix)";
				
				appDB.AddCommandParameter(cmd, "pJob", _pJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuffix", _pSuffix, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
