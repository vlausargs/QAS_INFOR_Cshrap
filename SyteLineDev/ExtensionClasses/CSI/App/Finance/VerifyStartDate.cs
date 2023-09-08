//PROJECT NAME: Finance
//CLASS NAME: VerifyStartDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class VerifyStartDate : IVerifyStartDate
	{
		readonly IApplicationDB appDB;
		
		
		public VerifyStartDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) VerifyStartDateSp(DateTime? PStartDate,
		int? PFiscalYear,
		string Infobar)
		{
			DateType _PStartDate = PStartDate;
			FiscalYearType _PFiscalYear = PFiscalYear;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VerifyStartDateSp";
				
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
