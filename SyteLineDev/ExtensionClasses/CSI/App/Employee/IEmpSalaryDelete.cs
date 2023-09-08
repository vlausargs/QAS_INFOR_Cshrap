//PROJECT NAME: Employee
//CLASS NAME: IEmpSalaryDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IEmpSalaryDelete
	{
		(int? ReturnCode,
		string Infobar) EmpSalaryDeleteSp(
			string EmpSalaryEmpNum,
			DateTime? EmpSalaryJobdate,
			DateTime? EmpSalarySalDate,
			string Infobar);
	}
}

