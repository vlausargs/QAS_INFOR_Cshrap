//PROJECT NAME: Employee
//CLASS NAME: IHrvacDoProcess.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IHrvacDoProcess
	{
		(int? ReturnCode, string Infobar) HrvacDoProcessSp(string pBegEmpNum,
		string pEndEmpNum,
		string DateMethod = "F",
		DateTime? FixedDate = null,
		string Infobar = null);
	}
}

