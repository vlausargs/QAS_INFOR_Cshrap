//PROJECT NAME: Codes
//CLASS NAME: GetFiscalYear.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class GetFiscalYear : IGetFiscalYear
	{
		readonly IApplicationDB appDB;
		
		
		public GetFiscalYear(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? pFiscalYear) GetFiscalYearSp(int? pFiscalYear)
		{
			FiscalYearType _pFiscalYear = pFiscalYear;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetFiscalYearSp";
				
				appDB.AddCommandParameter(cmd, "pFiscalYear", _pFiscalYear, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pFiscalYear = _pFiscalYear;
				
				return (Severity, pFiscalYear);
			}
		}
		public int? GetFiscalYearFn()
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetFiscalYear]()";

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}

	}
}
