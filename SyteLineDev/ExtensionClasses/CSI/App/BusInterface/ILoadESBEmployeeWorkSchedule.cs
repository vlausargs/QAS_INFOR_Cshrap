//PROJECT NAME: BusInterface
//CLASS NAME: ILoadESBEmployeeWorkSchedule.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ILoadESBEmployeeWorkSchedule
	{
		(int? ReturnCode, string Infobar) LoadESBEmployeeWorkScheduleSp(string ActionExpression = null,
		string DocumentID = null,
		string EmpNum = null,
		DateTime? LeaveStartDate = null,
		string LeaveDuration = null,
		DateTime? LeaveEndDate = null,
		string AbsenceType = null,
		string Status = null,
		string Infobar = null);
	}
}

