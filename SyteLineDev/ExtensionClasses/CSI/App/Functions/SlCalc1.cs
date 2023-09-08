//PROJECT NAME: Data
//CLASS NAME: SlCalc1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SlCalc1 : ISlCalc1
	{
		readonly IApplicationDB appDB;
		
		public SlCalc1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TYtd,
			string Infobar) SlCalc1Sp(
			DateTime? LowDate,
			DateTime? HighDate,
			DateTime? NextYearDate,
			DateTime? TADate,
			DateTime? TSlEnd,
			string EmpNum,
			DateTime? JobDate,
			string PositionClass,
			decimal? TYtd,
			string Infobar)
		{
			DateType _LowDate = LowDate;
			DateType _HighDate = HighDate;
			DateType _NextYearDate = NextYearDate;
			CurrentDateType _TADate = TADate;
			CurrentDateType _TSlEnd = TSlEnd;
			EmpNumType _EmpNum = EmpNum;
			DateType _JobDate = JobDate;
			PosClassType _PositionClass = PositionClass;
			DaysOffType _TYtd = TYtd;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SlCalc1Sp";
				
				appDB.AddCommandParameter(cmd, "LowDate", _LowDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HighDate", _HighDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NextYearDate", _NextYearDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TADate", _TADate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TSlEnd", _TSlEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDate", _JobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PositionClass", _PositionClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TYtd", _TYtd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TYtd = _TYtd;
				Infobar = _Infobar;
				
				return (Severity, TYtd, Infobar);
			}
		}
	}
}
