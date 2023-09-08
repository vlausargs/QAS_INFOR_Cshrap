//PROJECT NAME: Finance
//CLASS NAME: MultiFSBVerifyStartDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IMultiFSBVerifyStartDate
	{
		(int? ReturnCode, string Infobar) MultiFSBVerifyStartDateSp(string PeriodName,
		DateTime? PStartDate,
		short? PFiscalYear,
		string Infobar);
	}
	
	public class MultiFSBVerifyStartDate : IMultiFSBVerifyStartDate
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBVerifyStartDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) MultiFSBVerifyStartDateSp(string PeriodName,
		DateTime? PStartDate,
		short? PFiscalYear,
		string Infobar)
		{
			FSBPeriodNameType _PeriodName = PeriodName;
			DateType _PStartDate = PStartDate;
			FiscalYearType _PFiscalYear = PFiscalYear;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBVerifyStartDateSp";
				
				appDB.AddCommandParameter(cmd, "PeriodName", _PeriodName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartDate", _PStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFiscalYear", _PFiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
