//PROJECT NAME: Employee
//CLASS NAME: IRejectTimeOffRequest.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IRejectTimeOffRequest
	{
		(int? ReturnCode, string Inforbar) RejectTimeOffRequestSp(string EmpNum,
		DateTime? TimeOffStartDate,
		DateTime? TimeOffEndDate,
		string TimeOffManagerComments = null,
		string Inforbar = null);
	}
}

