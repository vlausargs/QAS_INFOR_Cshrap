//PROJECT NAME: Data
//CLASS NAME: ITmpMassJournalCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITmpMassJournalCheck
	{
		(int? ReturnCode,
			string Infobar) TmpMassJournalCheckSp(
			Guid? StartingSessionId,
			int? StartingNestingLevel,
			string Infobar);
	}
}

