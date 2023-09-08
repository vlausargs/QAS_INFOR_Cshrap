//PROJECT NAME: Finance
//CLASS NAME: IProcessTmpMassJournalBulk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IProcessTmpMassJournalBulk
	{
		int? ProcessTmpMassJournalBulkSp(Guid? ProcessId,
		int? BGTaskId);
	}
}

