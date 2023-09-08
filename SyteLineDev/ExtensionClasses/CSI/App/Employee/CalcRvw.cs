//PROJECT NAME: Employee
//CLASS NAME: CalcRvw.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class CalcRvw : ICalcRvw
	{
		readonly IApplicationDB appDB;
		
		
		public CalcRvw(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? EmpReviewDate) CalcRvwSp(string EmpNum,
		DateTime? EmpADate,
		DateTime? DatePers,
		DateTime? EmpReviewDate)
		{
			StringType _EmpNum = EmpNum;
			DateTimeType _EmpADate = EmpADate;
			DateTimeType _DatePers = DatePers;
			DateTimeType _EmpReviewDate = EmpReviewDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcRvwSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpADate", _EmpADate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DatePers", _DatePers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpReviewDate", _EmpReviewDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EmpReviewDate = _EmpReviewDate;
				
				return (Severity, EmpReviewDate);
			}
		}
	}
}
