//PROJECT NAME: Data
//CLASS NAME: IGetEmployeeName.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetEmployeeName
	{
		string GetEmployeeNameFn(
			string EmpNum);
	}
}

