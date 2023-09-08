//PROJECT NAME: Data
//CLASS NAME: FTJobrouteRunDur.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTJobrouteRunDur : IFTJobrouteRunDur
	{
		readonly IApplicationDB appDB;
		
		public FTJobrouteRunDur(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? FTJobrouteRunDurFn(
			string Job,
			int? Suffix,
			int? OperNum,
			decimal? Efficiency)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			EfficiencyType _Efficiency = Efficiency;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FTJobrouteRunDur](@Job, @Suffix, @OperNum, @Efficiency)";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Efficiency", _Efficiency, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
