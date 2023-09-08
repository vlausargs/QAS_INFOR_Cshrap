//PROJECT NAME: Logistics
//CLASS NAME: FTSLJobEfficiencyCalculation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLJobEfficiencyCalculation : IFTSLJobEfficiencyCalculation
	{
		readonly IApplicationDB appDB;
		
		
		public FTSLJobEfficiencyCalculation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? Color) FTSLJobEfficiencyCalculationSp(string Job,
		int? Suffix,
		int? Operation,
		DateTime? CurrDate,
		int? RefreshInterval,
		decimal? HighEfficiencyLevel,
		decimal? MediumEfficiencyLevel,
		DateTime? StartTime,
		int? Color)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _Operation = Operation;
			DateTimeType _CurrDate = CurrDate;
			CustSeqType _RefreshInterval = RefreshInterval;
			EfficiencyType _HighEfficiencyLevel = HighEfficiencyLevel;
			EfficiencyType _MediumEfficiencyLevel = MediumEfficiencyLevel;
			DateType _StartTime = StartTime;
			CustSeqType _Color = Color;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLJobEfficiencyCalculationSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Operation", _Operation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrDate", _CurrDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefreshInterval", _RefreshInterval, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HighEfficiencyLevel", _HighEfficiencyLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MediumEfficiencyLevel", _MediumEfficiencyLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartTime", _StartTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Color", _Color, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Color = _Color;
				
				return (Severity, Color);
			}
		}
	}
}
