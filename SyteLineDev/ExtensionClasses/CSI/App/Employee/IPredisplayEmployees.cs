//PROJECT NAME: Employee
//CLASS NAME: IPredisplayEmployees.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IPredisplayEmployees
	{
		(int? ReturnCode, int? PHourlyPerm,
		int? PSalaryPerm,
		int? PCheckSsnEnabled,
		int? Prenote) PredisplayEmployeesSp(int? PHourlyPerm,
		int? PSalaryPerm,
		int? PCheckSsnEnabled,
		int? Prenote = 1);
	}
}

