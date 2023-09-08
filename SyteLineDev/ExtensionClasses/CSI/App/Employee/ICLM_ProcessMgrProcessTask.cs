//PROJECT NAME: Employee
//CLASS NAME: ICLM_ProcessMgrProcessTask.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ICLM_ProcessMgrProcessTask
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ProcessMgrProcessTaskSp(decimal? ProcessId,
		DateTime? DueDate);
	}
}

