//PROJECT NAME: Production
//CLASS NAME: CalculateJobShrinkFactor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CalculateJobShrinkFactor : ICalculateJobShrinkFactor
	{
		readonly IApplicationDB appDB;
		
		public CalculateJobShrinkFactor(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? CalculateJobShrinkFactorFn(
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
				cmd.CommandText = "SELECT  dbo.[CalculateJobShrinkFactor](@Item, @Job, @JobSuffix)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
