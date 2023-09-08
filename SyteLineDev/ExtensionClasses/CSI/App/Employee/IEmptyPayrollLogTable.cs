//PROJECT NAME: Employee
//CLASS NAME: IEmptyPayrollLogTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IEmptyPayrollLogTable
	{
		int? EmptyPayrollLogTableSp();
	}
}

