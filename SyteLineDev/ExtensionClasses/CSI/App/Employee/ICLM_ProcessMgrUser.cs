//PROJECT NAME: Employee
//CLASS NAME: ICLM_ProcessMgrUser.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ICLM_ProcessMgrUser
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ProcessMgrUserSp();
	}
}

