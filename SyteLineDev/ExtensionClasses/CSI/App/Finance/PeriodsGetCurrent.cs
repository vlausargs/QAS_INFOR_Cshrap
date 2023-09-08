//PROJECT NAME: CSIFinance
//CLASS NAME: PeriodsGetCurrent.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IPeriodsGetCurrent
	{
		(int? ReturnCode, byte? PeriodsCurPer, short? PeriodsFiscalYear, string Infobar) PeriodsGetCurrentSp(string Site = null,
		byte? PeriodsCurPer = (byte)0,
		short? PeriodsFiscalYear = null,
		string Infobar = null);
	}
	
	public class PeriodsGetCurrent : IPeriodsGetCurrent
	{
		readonly IApplicationDB appDB;
		
		public PeriodsGetCurrent(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? PeriodsCurPer, short? PeriodsFiscalYear, string Infobar) PeriodsGetCurrentSp(string Site = null,
		byte? PeriodsCurPer = (byte)0,
		short? PeriodsFiscalYear = null,
		string Infobar = null)
		{
			SiteType _Site = Site;
			FinPeriodType _PeriodsCurPer = PeriodsCurPer;
			FiscalYearType _PeriodsFiscalYear = PeriodsFiscalYear;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PeriodsGetCurrentSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodsCurPer", _PeriodsCurPer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodsFiscalYear", _PeriodsFiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PeriodsCurPer = _PeriodsCurPer;
				PeriodsFiscalYear = _PeriodsFiscalYear;
				Infobar = _Infobar;
				
				return (Severity, PeriodsCurPer, PeriodsFiscalYear, Infobar);
			}
		}
	}
}
