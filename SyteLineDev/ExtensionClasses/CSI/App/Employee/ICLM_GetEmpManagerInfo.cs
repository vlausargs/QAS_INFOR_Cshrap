//PROJECT NAME: Employee
//CLASS NAME: ICLM_GetEmpManagerInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ICLM_GetEmpManagerInfo
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_GetEmpManagerInfoSp(
			string EmpNum = null,
			string UserName = null);
	}
}

