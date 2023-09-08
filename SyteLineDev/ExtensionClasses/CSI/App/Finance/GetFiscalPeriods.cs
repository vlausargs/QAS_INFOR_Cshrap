//PROJECT NAME: Finance
//CLASS NAME: GetFiscalPeriods.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GetFiscalPeriods : IGetFiscalPeriods
	{
		readonly IApplicationDB appDB;
		
		
		public GetFiscalPeriods(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? rPer1Start,
		DateTime? rPer2Start,
		DateTime? rPer3Start,
		DateTime? rPer4Start,
		DateTime? rPer5Start,
		DateTime? rPer6Start,
		DateTime? rPer7Start,
		DateTime? rPer8Start,
		DateTime? rPer9Start,
		DateTime? rPer10Start,
		DateTime? rPer11Start,
		DateTime? rPer12Start,
		DateTime? rPer13Start,
		DateTime? rPer1End,
		DateTime? rPer2End,
		DateTime? rPer3End,
		DateTime? rPer4End,
		DateTime? rPer5End,
		DateTime? rPer6End,
		DateTime? rPer7End,
		DateTime? rPer8End,
		DateTime? rPer9End,
		DateTime? rPer10End,
		DateTime? rPer11End,
		DateTime? rPer12End,
		DateTime? rPer13End,
		string Infobar) GetFiscalPeriodsSp(int? pFiscalYear,
		DateTime? rPer1Start,
		DateTime? rPer2Start,
		DateTime? rPer3Start,
		DateTime? rPer4Start,
		DateTime? rPer5Start,
		DateTime? rPer6Start,
		DateTime? rPer7Start,
		DateTime? rPer8Start,
		DateTime? rPer9Start,
		DateTime? rPer10Start,
		DateTime? rPer11Start,
		DateTime? rPer12Start,
		DateTime? rPer13Start,
		DateTime? rPer1End,
		DateTime? rPer2End,
		DateTime? rPer3End,
		DateTime? rPer4End,
		DateTime? rPer5End,
		DateTime? rPer6End,
		DateTime? rPer7End,
		DateTime? rPer8End,
		DateTime? rPer9End,
		DateTime? rPer10End,
		DateTime? rPer11End,
		DateTime? rPer12End,
		DateTime? rPer13End,
		string Infobar)
		{
			FiscalYearType _pFiscalYear = pFiscalYear;
			DateType _rPer1Start = rPer1Start;
			DateType _rPer2Start = rPer2Start;
			DateType _rPer3Start = rPer3Start;
			DateType _rPer4Start = rPer4Start;
			DateType _rPer5Start = rPer5Start;
			DateType _rPer6Start = rPer6Start;
			DateType _rPer7Start = rPer7Start;
			DateType _rPer8Start = rPer8Start;
			DateType _rPer9Start = rPer9Start;
			DateType _rPer10Start = rPer10Start;
			DateType _rPer11Start = rPer11Start;
			DateType _rPer12Start = rPer12Start;
			DateType _rPer13Start = rPer13Start;
			DateType _rPer1End = rPer1End;
			DateType _rPer2End = rPer2End;
			DateType _rPer3End = rPer3End;
			DateType _rPer4End = rPer4End;
			DateType _rPer5End = rPer5End;
			DateType _rPer6End = rPer6End;
			DateType _rPer7End = rPer7End;
			DateType _rPer8End = rPer8End;
			DateType _rPer9End = rPer9End;
			DateType _rPer10End = rPer10End;
			DateType _rPer11End = rPer11End;
			DateType _rPer12End = rPer12End;
			DateType _rPer13End = rPer13End;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetFiscalPeriodsSp";
				
				appDB.AddCommandParameter(cmd, "pFiscalYear", _pFiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rPer1Start", _rPer1Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer2Start", _rPer2Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer3Start", _rPer3Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer4Start", _rPer4Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer5Start", _rPer5Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer6Start", _rPer6Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer7Start", _rPer7Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer8Start", _rPer8Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer9Start", _rPer9Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer10Start", _rPer10Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer11Start", _rPer11Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer12Start", _rPer12Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer13Start", _rPer13Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer1End", _rPer1End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer2End", _rPer2End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer3End", _rPer3End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer4End", _rPer4End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer5End", _rPer5End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer6End", _rPer6End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer7End", _rPer7End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer8End", _rPer8End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer9End", _rPer9End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer10End", _rPer10End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer11End", _rPer11End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer12End", _rPer12End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rPer13End", _rPer13End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rPer1Start = _rPer1Start;
				rPer2Start = _rPer2Start;
				rPer3Start = _rPer3Start;
				rPer4Start = _rPer4Start;
				rPer5Start = _rPer5Start;
				rPer6Start = _rPer6Start;
				rPer7Start = _rPer7Start;
				rPer8Start = _rPer8Start;
				rPer9Start = _rPer9Start;
				rPer10Start = _rPer10Start;
				rPer11Start = _rPer11Start;
				rPer12Start = _rPer12Start;
				rPer13Start = _rPer13Start;
				rPer1End = _rPer1End;
				rPer2End = _rPer2End;
				rPer3End = _rPer3End;
				rPer4End = _rPer4End;
				rPer5End = _rPer5End;
				rPer6End = _rPer6End;
				rPer7End = _rPer7End;
				rPer8End = _rPer8End;
				rPer9End = _rPer9End;
				rPer10End = _rPer10End;
				rPer11End = _rPer11End;
				rPer12End = _rPer12End;
				rPer13End = _rPer13End;
				Infobar = _Infobar;
				
				return (Severity, rPer1Start, rPer2Start, rPer3Start, rPer4Start, rPer5Start, rPer6Start, rPer7Start, rPer8Start, rPer9Start, rPer10Start, rPer11Start, rPer12Start, rPer13Start, rPer1End, rPer2End, rPer3End, rPer4End, rPer5End, rPer6End, rPer7End, rPer8End, rPer9End, rPer10End, rPer11End, rPer12End, rPer13End, Infobar);
			}
		}
	}
}
