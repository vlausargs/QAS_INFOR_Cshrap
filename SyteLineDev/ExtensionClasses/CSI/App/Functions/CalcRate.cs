//PROJECT NAME: Data
//CLASS NAME: CalcRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CalcRate : ICalcRate
	{
		readonly IApplicationDB appDB;
		
		public CalcRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TPayRate) CalcRateSp(
			Guid? TEmpRecid,
			string THrType,
			int? TPaySalary,
			string TShift,
			DateTime? TEffDate,
			int? TSumAtt,
			decimal? TPayRate)
		{
			RowPointerType _TEmpRecid = TEmpRecid;
			AbsenceReasonCodeType _THrType = THrType;
			ListYesNoType _TPaySalary = TPaySalary;
			ShiftType _TShift = TShift;
			Date4Type _TEffDate = TEffDate;
			FlagNyType _TSumAtt = TSumAtt;
			PayRatePreciseType _TPayRate = TPayRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcRateSp";
				
				appDB.AddCommandParameter(cmd, "TEmpRecid", _TEmpRecid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "THrType", _THrType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPaySalary", _TPaySalary, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TShift", _TShift, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEffDate", _TEffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TSumAtt", _TSumAtt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPayRate", _TPayRate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TPayRate = _TPayRate;
				
				return (Severity, TPayRate);
			}
		}
	}
}
