//PROJECT NAME: Employee
//CLASS NAME: IPrLogRefreshEmpDefaults.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IPrLogRefreshEmpDefaults
	{
		(int? ReturnCode, string EmpName,
		int? EmpSeq,
		string EmpShift,
		string Infobar) PrLogRefreshEmpDefaultsSp(string EmpNum,
		string EmpName,
		int? EmpSeq,
		string EmpShift,
		string Infobar);
	}
}

