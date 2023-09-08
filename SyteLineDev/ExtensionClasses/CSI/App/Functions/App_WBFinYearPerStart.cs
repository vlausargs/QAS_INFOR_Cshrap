//PROJECT NAME: Data
//CLASS NAME: App_WBFinYearPerStart.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class App_WBFinYearPerStart : IApp_WBFinYearPerStart
	{
		readonly IApplicationDB appDB;
		
		public App_WBFinYearPerStart(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? PerStart,
			DateTime? YearStart,
			string Infobar,
			DateTime? PerEnd,
			DateTime? YearEnd) App_WBFinYearPerStartSp(
			DateTime? Date,
			DateTime? PerStart,
			DateTime? YearStart,
			string Infobar,
			DateTime? PerEnd = null,
			DateTime? YearEnd = null)
		{
			DateType _Date = Date;
			DateType _PerStart = PerStart;
			DateType _YearStart = YearStart;
			Infobar _Infobar = Infobar;
			DateType _PerEnd = PerEnd;
			DateType _YearEnd = YearEnd;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "App_WBFinYearPerStartSp";
				
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart", _PerStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "YearStart", _YearStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PerEnd", _PerEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "YearEnd", _YearEnd, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PerStart = _PerStart;
				YearStart = _YearStart;
				Infobar = _Infobar;
				PerEnd = _PerEnd;
				YearEnd = _YearEnd;
				
				return (Severity, PerStart, YearStart, Infobar, PerEnd, YearEnd);
			}
		}
	}
}
