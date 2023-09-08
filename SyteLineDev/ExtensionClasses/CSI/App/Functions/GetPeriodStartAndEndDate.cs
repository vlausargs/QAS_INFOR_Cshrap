//PROJECT NAME: Data
//CLASS NAME: GetPeriodStartAndEndDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetPeriodStartAndEndDate : IGetPeriodStartAndEndDate
	{
		readonly IApplicationDB appDB;
		
		public GetPeriodStartAndEndDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? PeriodStartDate,
			DateTime? PeriodEndDate) GetPeriodStartAndEndDateSp(
			DateTime? TransactionDate,
			DateTime? PeriodStartDate,
			DateTime? PeriodEndDate)
		{
			DateType _TransactionDate = TransactionDate;
			DateType _PeriodStartDate = PeriodStartDate;
			DateType _PeriodEndDate = PeriodEndDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPeriodStartAndEndDate";
				
				appDB.AddCommandParameter(cmd, "TransactionDate", _TransactionDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodStartDate", _PeriodStartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodEndDate", _PeriodEndDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PeriodStartDate = _PeriodStartDate;
				PeriodEndDate = _PeriodEndDate;
				
				return (Severity, PeriodStartDate, PeriodEndDate);
			}
		}
	}
}
