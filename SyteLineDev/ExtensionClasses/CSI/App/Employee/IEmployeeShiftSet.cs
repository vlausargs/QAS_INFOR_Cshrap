//PROJECT NAME: Employee
//CLASS NAME: IEmployeeShiftSet.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IEmployeeShiftSet
	{
		int? EmployeeShiftSetSp(string EmpNum,
		string Shift);
	}
}

