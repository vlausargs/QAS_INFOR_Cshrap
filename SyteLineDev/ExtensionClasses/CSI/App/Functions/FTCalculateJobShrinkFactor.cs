//PROJECT NAME: Data
//CLASS NAME: FTCalculateJobShrinkFactor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTCalculateJobShrinkFactor : IFTCalculateJobShrinkFactor
	{
		readonly IApplicationDB appDB;
		
		public FTCalculateJobShrinkFactor(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? FTCalculateJobShrinkFactorFn(
			string Item,
			string Job,
			int? JobSuffix)
		{
			ItemType _Item = Item;
			JobType _Job = Job;
			SuffixType _JobSuffix = JobSuffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FTCalculateJobShrinkFactor](@Item, @Job, @JobSuffix)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
