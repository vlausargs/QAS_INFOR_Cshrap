//PROJECT NAME: Finance
//CLASS NAME: PeriodsGetDates.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class PeriodsGetDates : IPeriodsGetDates
	{
		readonly IApplicationDB appDB;
		
		
		public PeriodsGetDates(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? PerStart,
		DateTime? PerEnd,
		string Infobar) PeriodsGetDatesSp(int? FiscalYear,
		int? Period,
		string Site = null,
		DateTime? PerStart = null,
		DateTime? PerEnd = null,
		string Infobar = null)
		{
			FiscalYearType _FiscalYear = FiscalYear;
			FinPeriodType _Period = Period;
			SiteType _Site = Site;
			DateType _PerStart = PerStart;
			DateType _PerEnd = PerEnd;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PeriodsGetDatesSp";
				
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Period", _Period, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart", _PerStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PerEnd", _PerEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PerStart = _PerStart;
				PerEnd = _PerEnd;
				Infobar = _Infobar;
				
				return (Severity, PerStart, PerEnd, Infobar);
			}
		}
	}
}
