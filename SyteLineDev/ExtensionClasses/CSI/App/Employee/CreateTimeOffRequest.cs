//PROJECT NAME: CSIEmployee
//CLASS NAME: CreateTimeOffRequest.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface ICreateTimeOffRequest
	{
		(int? ReturnCode, string Inforbar) CreateTimeOffRequestSp(string EmpNum,
		DateTime? TimeOffStartDate,
		DateTime? TimeOffEndDate,
		string ReasonCode,
		decimal? TimeOffHours,
		string TimeOffEmpComments = null,
		string Inforbar = null);
	}
	
	public class CreateTimeOffRequest : ICreateTimeOffRequest
	{
		readonly IApplicationDB appDB;
		
		public CreateTimeOffRequest(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Inforbar) CreateTimeOffRequestSp(string EmpNum,
		DateTime? TimeOffStartDate,
		DateTime? TimeOffEndDate,
		string ReasonCode,
		decimal? TimeOffHours,
		string TimeOffEmpComments = null,
		string Inforbar = null)
		{
			EmpNumType _EmpNum = EmpNum;
			DateType _TimeOffStartDate = TimeOffStartDate;
			DateType _TimeOffEndDate = TimeOffEndDate;
			AbsenceReasonCodeType _ReasonCode = ReasonCode;
			HoursOffType _TimeOffHours = TimeOffHours;
			LongDescType _TimeOffEmpComments = TimeOffEmpComments;
			InfobarType _Inforbar = Inforbar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateTimeOffRequestSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TimeOffStartDate", _TimeOffStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TimeOffEndDate", _TimeOffEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TimeOffHours", _TimeOffHours, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TimeOffEmpComments", _TimeOffEmpComments, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Inforbar", _Inforbar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Inforbar = _Inforbar;
				
				return (Severity, Inforbar);
			}
		}
	}
}
