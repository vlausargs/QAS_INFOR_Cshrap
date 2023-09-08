//PROJECT NAME: Employee
//CLASS NAME: IHrYearEnd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IHrYearEnd
	{
		(int? ReturnCode, string Infobar) HrYearEndSp(string StartingEmpNum = null,
		string EndingEmpNum = null,
		string DateMethod = "F",
		DateTime? FixedDate = null,
		string Infobar = null);
	}
}

