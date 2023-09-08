//PROJECT NAME: Finance
//CLASS NAME: GetFirstFiscalYear.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GetFirstFiscalYear : IGetFirstFiscalYear
	{
		readonly IApplicationDB appDB;
		
		
		public GetFirstFiscalYear(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? FirstFiscalYear) GetFirstFiscalYearSp(int? FirstFiscalYear)
		{
			IntType _FirstFiscalYear = FirstFiscalYear;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetFirstFiscalYearSp";
				
				appDB.AddCommandParameter(cmd, "FirstFiscalYear", _FirstFiscalYear, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FirstFiscalYear = _FirstFiscalYear;
				
				return (Severity, FirstFiscalYear);
			}
		}
	}
}
