//PROJECT NAME: Employee
//CLASS NAME: IProcessMgrAssignTo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IProcessMgrAssignTo
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProcessMgrAssignToSp(string JobId = null);
	}
}

