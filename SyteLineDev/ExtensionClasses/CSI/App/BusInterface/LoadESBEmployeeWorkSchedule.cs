//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBEmployeeWorkSchedule.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBEmployeeWorkSchedule : ILoadESBEmployeeWorkSchedule
	{
		readonly IApplicationDB appDB;
		
		
		public LoadESBEmployeeWorkSchedule(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) LoadESBEmployeeWorkScheduleSp(string ActionExpression = null,
		string DocumentID = null,
		string EmpNum = null,
		DateTime? LeaveStartDate = null,
		string LeaveDuration = null,
		DateTime? LeaveEndDate = null,
		string AbsenceType = null,
		string Status = null,
		string Infobar = null)
		{
			StringType _ActionExpression = ActionExpression;
			DocumentTypeType _DocumentID = DocumentID;
			EmpNumType _EmpNum = EmpNum;
			DateType _LeaveStartDate = LeaveStartDate;
			StringType _LeaveDuration = LeaveDuration;
			DateType _LeaveEndDate = LeaveEndDate;
			AbsenceReasonCodeType _AbsenceType = AbsenceType;
			StringType _Status = Status;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBEmployeeWorkScheduleSp";
				
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentID", _DocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LeaveStartDate", _LeaveStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LeaveDuration", _LeaveDuration, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LeaveEndDate", _LeaveEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AbsenceType", _AbsenceType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
