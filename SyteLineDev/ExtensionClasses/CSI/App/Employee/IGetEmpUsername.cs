//PROJECT NAME: Employee
//CLASS NAME: IGetEmpUsername.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IGetEmpUsername
	{
		(int? ReturnCode,
		string UserName) GetEmpUsernameSp(
			string EmpNum = null,
			string UserName = null);
	}
}

