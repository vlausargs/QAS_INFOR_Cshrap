//PROJECT NAME: Data
//CLASS NAME: SlCalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SlCalc : ISlCalc
	{
		readonly IApplicationDB appDB;
		
		public SlCalc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TotalYtd,
			string Infobar) SlCalcSp(
			DateTime? LowDate,
			DateTime? HighDate,
			DateTime? NextYearDate,
			string EmpNum,
			decimal? DaysCf,
			decimal? DaysUsed,
			decimal? TotalYtd,
			string Infobar)
		{
			DateType _LowDate = LowDate;
			DateType _HighDate = HighDate;
			DateType _NextYearDate = NextYearDate;
			EmpNumType _EmpNum = EmpNum;
			DaysCarriedForwardType _DaysCf = DaysCf;
			DaysOffType _DaysUsed = DaysUsed;
			DaysOffType _TotalYtd = TotalYtd;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SlCalcSp";
				
				appDB.AddCommandParameter(cmd, "LowDate", _LowDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HighDate", _HighDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NextYearDate", _NextYearDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DaysCf", _DaysCf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DaysUsed", _DaysUsed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TotalYtd", _TotalYtd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TotalYtd = _TotalYtd;
				Infobar = _Infobar;
				
				return (Severity, TotalYtd, Infobar);
			}
		}
	}
}
