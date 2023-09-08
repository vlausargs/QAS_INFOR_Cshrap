//PROJECT NAME: Finance
//CLASS NAME: VerifyEndDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class VerifyEndDate : IVerifyEndDate
	{
		readonly IApplicationDB appDB;
		
		
		public VerifyEndDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) VerifyEndDateSp(int? PFiscalYear,
		string Infobar)
		{
			FiscalYearType _PFiscalYear = PFiscalYear;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VerifyEndDateSp";
				
				appDB.AddCommandParameter(cmd, "PFiscalYear", _PFiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
