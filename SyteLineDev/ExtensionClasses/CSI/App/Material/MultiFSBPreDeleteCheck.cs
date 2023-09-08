//PROJECT NAME: Finance
//CLASS NAME: MultiFSBPreDeleteCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBPreDeleteCheck : IMultiFSBPreDeleteCheck
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBPreDeleteCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MultiFSBPreDeleteCheckSp(
			string PeriodName,
			int? FiscalYear,
			string Infobar)
		{
			FSBPeriodNameType _PeriodName = PeriodName;
			FiscalYearType _FiscalYear = FiscalYear;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBPreDeleteCheckSp";
				
				appDB.AddCommandParameter(cmd, "PeriodName", _PeriodName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
