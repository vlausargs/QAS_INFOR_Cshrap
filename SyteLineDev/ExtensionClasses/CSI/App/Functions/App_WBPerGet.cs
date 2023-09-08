//PROJECT NAME: Data
//CLASS NAME: App_WBPerGet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class App_WBPerGet : IApp_WBPerGet
	{
		readonly IApplicationDB appDB;
		
		public App_WBPerGet(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? PerStart,
			DateTime? PerEnd,
			int? WorkDays,
			int? TotDays,
			string Infobar) App_WBPerGetSp(
			DateTime? AsOfDate,
			DateTime? PerStart,
			DateTime? PerEnd,
			int? WorkDays,
			int? TotDays,
			string Infobar)
		{
			DateType _AsOfDate = AsOfDate;
			DateType _PerStart = PerStart;
			DateType _PerEnd = PerEnd;
			IntType _WorkDays = WorkDays;
			IntType _TotDays = TotDays;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "App_WBPerGetSp";
				
				appDB.AddCommandParameter(cmd, "AsOfDate", _AsOfDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart", _PerStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PerEnd", _PerEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WorkDays", _WorkDays, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotDays", _TotDays, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PerStart = _PerStart;
				PerEnd = _PerEnd;
				WorkDays = _WorkDays;
				TotDays = _TotDays;
				Infobar = _Infobar;
				
				return (Severity, PerStart, PerEnd, WorkDays, TotDays, Infobar);
			}
		}
	}
}
