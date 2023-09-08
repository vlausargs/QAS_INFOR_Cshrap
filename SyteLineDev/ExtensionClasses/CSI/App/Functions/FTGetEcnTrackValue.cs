//PROJECT NAME: Data
//CLASS NAME: FTGetEcnTrackValue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTGetEcnTrackValue : IFTGetEcnTrackValue
	{
		readonly IApplicationDB appDB;
		
		public FTGetEcnTrackValue(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? FTGetEcnTrackValueFn(
			string Item,
			string Job,
			int? Suffix,
			string JobType)
		{
			ItemType _Item = Item;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			JobType _JobType = JobType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FTGetEcnTrackValue](@Item, @Job, @Suffix, @JobType)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
