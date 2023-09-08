//PROJECT NAME: Data
//CLASS NAME: JobOrdersEnableItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobOrdersEnableItem : IJobOrdersEnableItem
	{
		readonly IApplicationDB appDB;
		
		public JobOrdersEnableItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? JobOrdersEnableItemFn(
			string Stat,
			string Job,
			int? Suffix)
		{
			JobStatusType _Stat = Stat;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[JobOrdersEnableItem](@Stat, @Job, @Suffix)";
				
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
