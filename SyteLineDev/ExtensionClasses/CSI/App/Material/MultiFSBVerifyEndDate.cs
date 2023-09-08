//PROJECT NAME: Finance
//CLASS NAME: MultiFSBVerifyEndDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBVerifyEndDate : IMultiFSBVerifyEndDate
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBVerifyEndDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MultiFSBVerifyEndDateSp(
			string PeriodName,
			int? PFiscalYear,
			string Infobar)
		{
			FSBPeriodNameType _PeriodName = PeriodName;
			FiscalYearType _PFiscalYear = PFiscalYear;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBVerifyEndDateSp";
				
				appDB.AddCommandParameter(cmd, "PeriodName", _PeriodName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFiscalYear", _PFiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
