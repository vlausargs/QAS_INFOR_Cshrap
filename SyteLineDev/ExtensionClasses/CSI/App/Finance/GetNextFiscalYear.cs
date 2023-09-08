//PROJECT NAME: Finance
//CLASS NAME: GetNextFiscalYear.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GetNextFiscalYear : IGetNextFiscalYear
	{
		readonly IApplicationDB appDB;
		
		
		public GetNextFiscalYear(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? NextFiscalYear) GetNextFiscalYearSp(int? NextFiscalYear)
		{
			IntType _NextFiscalYear = NextFiscalYear;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetNextFiscalYearSp";
				
				appDB.AddCommandParameter(cmd, "NextFiscalYear", _NextFiscalYear, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NextFiscalYear = _NextFiscalYear;
				
				return (Severity, NextFiscalYear);
			}
		}
	}
}
