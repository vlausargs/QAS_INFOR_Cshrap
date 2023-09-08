//PROJECT NAME: Finance
//CLASS NAME: FinRptOutputGetPeriod1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FinRptOutputGetPeriod1 : IFinRptOutputGetPeriod1
	{
		readonly IApplicationDB appDB;
		
		
		public FinRptOutputGetPeriod1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? YearStart,
		int? Period,
		DateTime? PeriodStart,
		DateTime? PeriodEnd,
		string Infobar) FinRptOutputGetPeriod1Sp(DateTime? YearStart,
		int? Period,
		DateTime? PeriodStart,
		DateTime? PeriodEnd,
		string Site = null,
		string Infobar = null)
		{
			DateType _YearStart = YearStart;
			FinPeriodType _Period = Period;
			DateType _PeriodStart = PeriodStart;
			DateType _PeriodEnd = PeriodEnd;
			SiteType _Site = Site;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FinRptOutputGetPeriod1Sp";
				
				appDB.AddCommandParameter(cmd, "YearStart", _YearStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Period", _Period, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodStart", _PeriodStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodEnd", _PeriodEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				YearStart = _YearStart;
				Period = _Period;
				PeriodStart = _PeriodStart;
				PeriodEnd = _PeriodEnd;
				Infobar = _Infobar;
				
				return (Severity, YearStart, Period, PeriodStart, PeriodEnd, Infobar);
			}
		}
	}
}
