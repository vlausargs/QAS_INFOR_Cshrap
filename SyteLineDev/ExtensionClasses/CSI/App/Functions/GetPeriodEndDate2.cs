//PROJECT NAME: Data
//CLASS NAME: GetPeriodEndDate2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetPeriodEndDate2 : IGetPeriodEndDate2
	{
		readonly IApplicationDB appDB;
		
		public GetPeriodEndDate2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetPeriodEndDate2Fn(
			int? PPeriod,
			int? FiscalYear)
		{
			FinPeriodType _PPeriod = PPeriod;
			FiscalYearType _FiscalYear = FiscalYear;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetPeriodEndDate2](@PPeriod, @FiscalYear)";
				
				appDB.AddCommandParameter(cmd, "PPeriod", _PPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
