//PROJECT NAME: Reporting
//CLASS NAME: IGLBudgetCommit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IGLBudgetCommit
	{
		(int? ReturnCode,
			string Infobar) GLBudgetCommitSp(
			Guid? SessionID,
			string Infobar);
	}
}

