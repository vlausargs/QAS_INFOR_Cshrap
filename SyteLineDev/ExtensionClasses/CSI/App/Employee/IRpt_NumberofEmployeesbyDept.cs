//PROJECT NAME: Employee
//CLASS NAME: IRpt_NumberofEmployeesbyDept.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IRpt_NumberofEmployeesbyDept
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_NumberofEmployeesbyDeptSp(string StartingDept = null,
		string EndingDept = null,
		string EmpStatus = null,
		int? DisplayHeader = null,
		Guid? BGSessionID = null,
		string pSite = null,
		string BGUser = null);
	}
}

