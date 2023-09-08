//PROJECT NAME: Production
//CLASS NAME: StartEndDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class StartEndDate : IStartEndDate
	{
		readonly IApplicationDB appDB;
		
		
		public StartEndDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? StartDate,
		DateTime? EndDate,
		int? RowCount) StartEndDateSp(string RefNum,
		int? RefLineSuf,
		DateTime? StartDate,
		DateTime? EndDate,
		int? RowCount)
		{
			JobPoReqNumType _RefNum = RefNum;
			SuffixPoReqLineType _RefLineSuf = RefLineSuf;
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			IntType _RowCount = RowCount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "StartEndDateSp";
				
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RowCount", _RowCount, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				StartDate = _StartDate;
				EndDate = _EndDate;
				RowCount = _RowCount;
				
				return (Severity, StartDate, EndDate, RowCount);
			}
		}
	}
}
