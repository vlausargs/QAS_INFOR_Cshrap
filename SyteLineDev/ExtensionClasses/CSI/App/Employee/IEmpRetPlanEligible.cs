//PROJECT NAME: Employee
//CLASS NAME: IEmpRetPlanEligible.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IEmpRetPlanEligible
	{
		(int? ReturnCode, string Infobar) EmpRetPlanEligibleSp(string PDeCode,
		string PEmpType,
		string Infobar);
	}
}

