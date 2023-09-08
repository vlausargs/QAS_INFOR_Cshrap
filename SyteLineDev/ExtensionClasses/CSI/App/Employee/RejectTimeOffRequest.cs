//PROJECT NAME: Employee
//CLASS NAME: RejectTimeOffRequest.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class RejectTimeOffRequest : IRejectTimeOffRequest
	{
		readonly IApplicationDB appDB;
		
		
		public RejectTimeOffRequest(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Inforbar) RejectTimeOffRequestSp(string EmpNum,
		DateTime? TimeOffStartDate,
		DateTime? TimeOffEndDate,
		string TimeOffManagerComments = null,
		string Inforbar = null)
		{
			EmpNumType _EmpNum = EmpNum;
			DateType _TimeOffStartDate = TimeOffStartDate;
			DateType _TimeOffEndDate = TimeOffEndDate;
			LongDescType _TimeOffManagerComments = TimeOffManagerComments;
			InfobarType _Inforbar = Inforbar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RejectTimeOffRequestSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TimeOffStartDate", _TimeOffStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TimeOffEndDate", _TimeOffEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TimeOffManagerComments", _TimeOffManagerComments, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Inforbar", _Inforbar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Inforbar = _Inforbar;
				
				return (Severity, Inforbar);
			}
		}
	}
}
