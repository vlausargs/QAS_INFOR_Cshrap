//PROJECT NAME: Employee
//CLASS NAME: ICLM_ESSGetPTOAccruedTakenBalance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ICLM_ESSGetPTOAccruedTakenBalance
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESSGetPTOAccruedTakenBalanceSp(string EmpNum);
	}
}

